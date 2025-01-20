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
        public decimal Subtotal { get; set; }
        public virtual Atendimento Atendimento { get; set; }
        public virtual Procedimento Procedimento { get; set; }
        public virtual Funcionario Funcionario { get; set; }

        public void Validar()
        {
            if (IdProcedimento == 0)
                throw new ArgumentException("É obrigatório informar o procedimento");

            if (IdFuncionario == 0)
                throw new ArgumentException("É obrigatório informar o funcionário");

            if (Quantidade == 0)
                throw new ArgumentException("É obrigatório informar a quantidade");
        }

        public void CalcularSubtotal()
        {
            Subtotal = Procedimento.Preco * Quantidade;
        }
    }
}
