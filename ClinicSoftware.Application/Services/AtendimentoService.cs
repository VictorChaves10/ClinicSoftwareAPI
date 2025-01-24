using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Atendimentos;
using ClinicSoftware.Domain.Interfaces;
using FluentValidation;

namespace ClinicSoftware.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<AtendimentoDto> _validator;

        public AtendimentoService(IUnitOfWork unitOfWork, IMapper mapper, IValidator<AtendimentoDto> validator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<AtendimentoDto> AddAtendimentoAsync(AtendimentoDto atendimentoDto)
        {
            _validator.ValidateAndThrow(atendimentoDto);

            var atendimento = new Atendimento
            {
                IdCliente = atendimentoDto.IdCliente,
                DataHoraAtendimento = atendimentoDto.DataHoraAtendimento,
                DataRegistro = DateTime.UtcNow,
                Observacao = atendimentoDto.Observacao,            
            };

            await _unitOfWork.AtendimentoRepository.AddAtendimentoAsync(atendimento);
            await _unitOfWork.CommitAsync();

            atendimentoDto.Id = atendimento.Id;
            return atendimentoDto;
        }
    }
}
