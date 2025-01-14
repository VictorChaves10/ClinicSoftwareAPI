using ClinicSoftware.Domain.Entities.Procedimentos;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;

namespace ClinicSoftware.Infrastructure.Repositories
{
    public class ProcedimentoRepository(ApplicationDbContext context) : RepositoryBase<Procedimento>(context), IProcedimentoRepository
    {
    }
}
