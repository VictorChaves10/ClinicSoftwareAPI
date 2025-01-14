using ClinicSoftware.Application.DTOs;

namespace ClinicSoftware.Application.Interfaces
{
    public interface IProcedimentoService
    {
        Task<IEnumerable<ProcedimentoDto>> GetProcedimentos();
        Task<ProcedimentoDto> GetProcedimentoDtoId(long id);
        Task Add(ProcedimentoDto procedimentoDto);
        Task Delete(long id);
        Task Update(ProcedimentoDto procedimentoDto);
    }
}
