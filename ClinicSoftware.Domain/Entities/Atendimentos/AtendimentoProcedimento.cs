using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;
using System.Text.Json.Serialization;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class AtendimentoProcedimento
    {
        public long Id { get; set; }
        public long IdAtendimento { get; set; }
        public long IdProcedimento { get; set; }
        public long IdFuncionario { get; set; }
        public int Quantidade { get; set; }
        public decimal Subtotal => Quantidade * (Procedimento?.Preco ?? 0);
        public virtual Atendimento Atendimento { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public virtual Funcionario Funcionario { get; set; }
    }
}
