using ClinicSoftware.Application.DTOs;

namespace ClinicSoftware.Application.Interfaces
{
    public interface IAtendimentoService
    {
        
        Task<AtendimentoDto> AddAtendimentoAsync(AtendimentoDto atendimentoDto);

        Task<AtendimentoDto> GetAtendimentoByIdAsync(long id);
    }
}
