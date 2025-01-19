using ClinicSoftware.Domain.Entities.Clientes;
using ClinicSoftware.Domain.Entities.Financeiro;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class Atendimento
    {
        public Atendimento()
        {
            Procedimentos = new List<AtendimentoProcedimento>();
            DataRegistro = DateTime.Now;
            Validar();
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
        public virtual ICollection<AtendimentoProcedimento> Procedimentos { get; set; }

        public void Validar()
        {
            if (IdCliente == 0)
                throw new ArgumentException("O cliente é obrigatório.");

            if (IdPagamento == 0)
                throw new ArgumentException("O pagamento é obrigatório.");

            if (DataRegistro == default)
                DataRegistro = DateTime.Now;
        }
    }
}
