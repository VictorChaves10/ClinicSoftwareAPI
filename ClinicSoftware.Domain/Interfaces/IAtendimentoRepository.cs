using ClinicSoftware.Domain.Entities.Atendimentos;

namespace ClinicSoftware.Domain.Interfaces;

public interface IAtendimentoRepository
{
    Task<Atendimento> AddAtendimentoAsync(Atendimento atendimento);
    Task<Atendimento> ObterAtendimentoPorIdAsync(long id);
}
