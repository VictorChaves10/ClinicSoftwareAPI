namespace ClinicSoftware.Domain.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository ClienteRepository { get; }
    IFuncionarioRepository FuncionarioRepository { get; }
    Task CommitAsync();
}
