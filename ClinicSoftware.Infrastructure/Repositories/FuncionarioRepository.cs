using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;

namespace ClinicSoftware.Infrastructure.Repositories
{
    public class FuncionarioRepository(ApplicationDbContext context) : RepositoryBase<Funcionario>(context), IFuncionarioRepository
    {

    }
}
