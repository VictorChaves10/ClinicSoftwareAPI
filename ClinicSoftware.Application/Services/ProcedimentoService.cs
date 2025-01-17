using AutoMapper;
using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Procedimentos;
using ClinicSoftware.Domain.Interfaces;

namespace ClinicSoftware.Application.Services
{
    public class ProcedimentoService(IMapper mapper, IUnitOfWork unitOfWork) : IProcedimentoService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public async Task<IEnumerable<ProcedimentoDto>> GetProcedimentos()
        {
            var procedimentos = await _unitOfWork.ProcedimentoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProcedimentoDto>>(procedimentos);
        }

        public async Task<ProcedimentoDto> GetProcedimentoById(long id)
        {
            var procedimento = await _unitOfWork.ProcedimentoRepository.GetAsync(x => x.Id == id);
            return _mapper.Map<ProcedimentoDto>(procedimento);
        }

        public async Task Add(ProcedimentoDto procedimentoDto)
        {
            var procedimento = _mapper.Map<Procedimento>(procedimentoDto);

            _unitOfWork.ProcedimentoRepository.Create(procedimento);
            await _unitOfWork.CommitAsync();

            procedimentoDto.Id = procedimento.Id;
        }
        public async Task Update(ProcedimentoDto procedimentoDto)
        {
            var procedimento = _mapper.Map<Procedimento>(procedimentoDto);

            _unitOfWork.ProcedimentoRepository.Update(procedimento);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(long id)
        {
            var procedimento = await _unitOfWork.ProcedimentoRepository.GetAsync(x => x.Id == id);

            _unitOfWork.ProcedimentoRepository.Delete(procedimento);
            await _unitOfWork.CommitAsync();
        }


    }
}
