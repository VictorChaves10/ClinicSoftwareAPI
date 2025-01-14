namespace ClinicSoftware.Domain.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository ClienteRepository { get; }
    IFuncionarioRepository FuncionarioRepository { get; }
    IProcedimentoRepository ProcedimentoRepository { get; }
    Task CommitAsync();
}
