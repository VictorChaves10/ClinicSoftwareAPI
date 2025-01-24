using ClinicSoftware.Domain.Entities.Clientes;
using ClinicSoftware.Domain.Entities.Financeiro;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class Atendimento
    {
        public Atendimento()
        {
            DataRegistro = DateTime.Now;
        }

        public long Id { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Observacao { get; set; }
        public long IdPagamento { get; set; }
        public long? IdDesconto { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Pagamento Pagamento { get; set; }
        public virtual Desconto Desconto { get; set; }
        public virtual ICollection<AtendimentoProcedimento> Procedimentos { get; private set; }

        public void AdicionarProcedimento(AtendimentoProcedimento procedimento)
        {
            if (procedimento == null)
                throw new ArgumentNullException(nameof(procedimento));

            if (Procedimentos.Any(p => p.Id == procedimento.Id))
                throw new InvalidOperationException("Procedimento já adicionado.");

            Procedimentos.Add(procedimento);
        }

        public void RemoverProcedimento(AtendimentoProcedimento atendimentoProcedimento)
        {
            Procedimentos.Remove(atendimentoProcedimento);
        }
    }
}
