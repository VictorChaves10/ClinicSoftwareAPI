using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;

namespace ClinicSoftware.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public ApplicationDbContext _context = context;
    
    private IClienteRepository _clienteRepository;
    private IFuncionarioRepository _funcionarioRepository;

    public IClienteRepository ClienteRepository
    {
        get 
        { 
            return _clienteRepository ??= new ClienteRepository(_context);
        }
    }

    public IFuncionarioRepository FuncionarioRepository
    {
        get
        {
            return _funcionarioRepository ??= new FuncionarioRepository(_context);
        }
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {         
        _context.Dispose();
    }
}
