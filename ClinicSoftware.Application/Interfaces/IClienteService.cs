using ClinicSoftware.Application.DTOs;

namespace ClinicSoftware.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetClientes();
    Task<ClienteDto> GetClienteById(long id);
    Task Add(ClienteDto cliente);
    Task Delete(long id);
    Task Update(ClienteDto cliente);
}
