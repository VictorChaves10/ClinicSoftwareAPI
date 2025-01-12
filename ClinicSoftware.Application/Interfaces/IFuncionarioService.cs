using ClinicSoftware.Application.Dtos;

namespace ClinicSoftware.Application.Interfaces
{
    public interface IFuncionarioService
    {
        Task<IEnumerable<FuncionarioDto>> GetFuncionarios();
        Task<FuncionarioDto> GetFuncionarioById(long id);
        Task Add(FuncionarioDto funcionarioDto);
        Task Delete(long id);
        Task Update(FuncionarioDto funcionarioDto);
    }
}
