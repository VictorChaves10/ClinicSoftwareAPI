namespace ClinicSoftware.Domain.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository ClienteRepository { get; }
    IFuncionarioRepository FuncionarioRepository { get; }
    IProcedimentoRepository ProcedimentoRepository { get; }
    IFinanceiroRepository FinanceiroRepository { get; }
    IAtendimentoRepository AtendimentoRepository { get; }
    Task CommitAsync();
}
