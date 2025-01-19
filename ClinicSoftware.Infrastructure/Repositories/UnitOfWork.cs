using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;

namespace ClinicSoftware.Infrastructure.Repositories;

public class UnitOfWork(ApplicationDbContext context) : IUnitOfWork
{
    public ApplicationDbContext _context = context;
    
    private IClienteRepository _clienteRepository;
    private IFuncionarioRepository _funcionarioRepository;
    private IProcedimentoRepository _procedimentoRepository;
    private IFinanceiroRepository _financeiroRepository;
    private IAtendimentoRepository _atendimentoRepository;

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

    public IProcedimentoRepository ProcedimentoRepository 
    {
        get 
        { 
            return _procedimentoRepository ??= new ProcedimentoRepository(_context);
        }
    }

    public IFinanceiroRepository FinanceiroRepository
    {
        get
        {
            return _financeiroRepository ??= new FinanceiroRepository(_context);
        }
    }

    public IAtendimentoRepository AtendimentoRepository
    {
        get {
            return _atendimentoRepository ??= new AtendimentoRepository(_context);
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
