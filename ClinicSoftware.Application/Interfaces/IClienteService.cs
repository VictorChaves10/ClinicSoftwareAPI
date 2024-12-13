using ClinicSoftware.Application.DTOs;

namespace ClinicSoftware.Application.Interfaces;

public interface IClienteService
{
    Task<IEnumerable<ClienteDto>> GetClientes(ClienteDto cliente);
    Task<ClienteDto> GetClienteById(int id);
    Task Add(ClienteDto cliente);
    Task Delete(ClienteDto cliente);
    Task Update(ClienteDto cliente);
}
