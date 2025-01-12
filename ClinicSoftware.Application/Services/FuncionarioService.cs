using AutoMapper;
using ClinicSoftware.Application.Dtos;
using ClinicSoftware.Application.Interfaces;
using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Interfaces;

namespace ClinicSoftware.Application.Services
{
    public class FuncionarioService(IMapper mapper, IUnitOfWork unitOfWork) : IFuncionarioService
    {
        private readonly IMapper _mapper = mapper;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public async Task<IEnumerable<FuncionarioDto>> GetFuncionarios()
        {
            var funcionarios = await _unitOfWork.FuncionarioRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FuncionarioDto>>(funcionarios);
        }

        public async Task<FuncionarioDto> GetFuncionarioById(long id)
        {
            var funcionario= await _unitOfWork.FuncionarioRepository.GetAsync(x => x.Id == id);
            return _mapper.Map<FuncionarioDto>(funcionario);
        }

        public async Task Add(FuncionarioDto funcionarioDto)
        {
            var funcionario = _mapper.Map<Funcionario>(funcionarioDto);
            
            _unitOfWork.FuncionarioRepository.Create(funcionario);
            await _unitOfWork.CommitAsync();            
            funcionarioDto.Id = funcionario.Id;
        }

        public async Task Update(FuncionarioDto funcionarioDto)
        {
            var funcionario = _mapper.Map<Funcionario>(funcionarioDto);
            
            _unitOfWork.FuncionarioRepository.Update(funcionario);
            await _unitOfWork.CommitAsync();
        }

        public async Task Delete(long id)
        {
            var funcionario = await _unitOfWork.FuncionarioRepository.GetAsync(x => x.Id == id);

            _unitOfWork.FuncionarioRepository.Delete(funcionario);
            await _unitOfWork.CommitAsync();
        }
    }
}
