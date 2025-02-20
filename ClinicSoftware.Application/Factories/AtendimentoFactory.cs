using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Atendimentos;
using ClinicSoftware.Domain.Interfaces;

namespace ClinicSoftware.Application.Factories
{
    public class AtendimentoFactory : IAtendimentoFactory
    {
        private readonly IMapper _mapper;
        private readonly IProcedimentoRepository _procedimentoRepository;

        public AtendimentoFactory(IMapper mapper, IProcedimentoRepository procedimentoRepository)
        {
            _mapper = mapper;
            _procedimentoRepository = procedimentoRepository;
        }

        public Atendimento CreateAtendimento(AtendimentoDto atendimentoDto)
        {
            var atendimento = _mapper.Map<Atendimento>(atendimentoDto);
            return atendimento;
        }
    }
}
