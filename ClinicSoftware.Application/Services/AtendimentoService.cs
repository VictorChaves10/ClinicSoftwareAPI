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

            var idsProcedimentos = atendimentoDto.Procedimentos.Select(x => x.IdProcedimento).ToList();
            var procedimentos = _unitOfWork.ProcedimentoRepository.GetAsync(x => idsProcedimentos.Contains(x.Id));

            var atendimentoProcedimentos = _mapper.Map<List<AtendimentoProcedimento>>(atendimentoDto.Procedimentos);

            foreach (var item in atendimentoProcedimentos)
            {
                procedimentos.FirstOrDefault(x => x.Id == atendimentoProcedimento.IdProcedimento);

                item.Validar();
                item.CalcularSubtotal();
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
