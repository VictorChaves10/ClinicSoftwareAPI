using ClinicSoftware.Domain.Entities.Clientes;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;

namespace ClinicSoftware.Infrastructure.Repositories;

public class ClienteRepository(ApplicationDbContext context) : RepositoryBase<Cliente>(context), IClienteRepository
{


}
