using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Atendimentos;
using ClinicSoftware.Domain.Entities.Financeiro;
using ClinicSoftware.Domain.Interfaces;

namespace ClinicSoftware.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AtendimentoService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AtendimentoDto> AddAtendimentoAsync(AtendimentoDto atendimentoDto)
        {

            if (atendimentoDto.Procedimentos == null || atendimentoDto.Procedimentos.Count == 0)
                throw new ArgumentException("É necessário informar ao menos um procedimento.");

            var cliente = await _unitOfWork.ClienteRepository.GetAsync(x => x.Id == atendimentoDto.IdCliente);

            if (cliente == null)
                throw new ArgumentException("Cliente não encontrado.");

            var pagamento = _mapper.Map<Pagamento>(atendimentoDto.Pagamento);
            var atendimentoProcedimentos = _mapper.Map<List<AtendimentoProcedimento>>(atendimentoDto.Procedimentos);

            foreach (var atendimentoProcedimento in atendimentoProcedimentos)
            {
                atendimentoProcedimento.Validar();
                atendimentoProcedimento.CalcularSubtotal();
            }

            var atendimento = new Atendimento
            {
                IdCliente = atendimentoDto.IdCliente,
                DataHoraAtendimento = atendimentoDto.DataHoraAtendimento,
                DataRegistro = DateTime.UtcNow,
                Observacao = atendimentoDto.Observacao,
                Pagamento = pagamento,
                Procedimentos = atendimentoProcedimentos                
            };
            
            await _unitOfWork.AtendimentoRepository.AddAtendimentoAsync(atendimento);
            await _unitOfWork.CommitAsync();

            atendimentoDto.Id = atendimento.Id;
            return atendimentoDto;
        }
    }
}
