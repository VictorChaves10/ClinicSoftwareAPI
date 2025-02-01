using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Interfaces;
using FluentValidation;

namespace ClinicSoftware.Application.Services
{
    public class AtendimentoService : IAtendimentoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAtendimentoFactory _atendimentoFactory;
        private readonly IValidator<AtendimentoDto> _validator;
        private readonly IMapper _mapper;

        public AtendimentoService(IUnitOfWork unitOfWork, IAtendimentoFactory atendimentoFactory, IValidator<AtendimentoDto> validator, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _atendimentoFactory = atendimentoFactory;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<AtendimentoDto> GetAtendimentoByIdAsync(long id)
        {
            var atendimento = await _unitOfWork.AtendimentoRepository.ObterAtendimentoPorIdAsync(id);

            var atendimentoDto = _mapper.Map<AtendimentoDto>(atendimento);

            return atendimentoDto;
        }

        public async Task<AtendimentoDto> AddAtendimentoAsync(AtendimentoDto atendimentoDto)
        {
            _validator.ValidateAndThrow(atendimentoDto);
            var atendimento = _atendimentoFactory.CreateAtendimento(atendimentoDto);

            await _unitOfWork.AtendimentoRepository.AddAtendimentoAsync(atendimento);
            await _unitOfWork.CommitAsync();

            atendimentoDto.Id = atendimento.Id;
            return atendimentoDto;
        }

    }
}
