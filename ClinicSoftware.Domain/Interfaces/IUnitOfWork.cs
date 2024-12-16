namespace ClinicSoftware.Domain.Interfaces;

public interface IUnitOfWork
{
    IClienteRepository ClienteRepository { get; }
    Task CommitAsync();
}
