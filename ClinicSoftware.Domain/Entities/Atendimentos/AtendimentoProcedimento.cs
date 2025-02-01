using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class AtendimentoProcedimento
    {
        public long Id { get; set; }
        public long IdAtendimento { get; set; }
        public long IdProcedimento { get; set; }
        public long IdFuncionario { get; set; }
        public int Quantidade { get; set; }
        public virtual Atendimento Atendimento { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public decimal CalcularSubtotal()
        {
            return Procedimento.Preco * Quantidade;
        }
    }
}
