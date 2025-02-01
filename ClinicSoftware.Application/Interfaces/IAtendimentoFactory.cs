using ClinicSoftware.Application.DTOs;
using ClinicSoftware.Domain.Entities.Atendimentos;

namespace ClinicSoftware.Application.Interfaces
{
    public interface IAtendimentoFactory
    {
        Atendimento CreateAtendimento(AtendimentoDto atendimentoDto);
    }
}
