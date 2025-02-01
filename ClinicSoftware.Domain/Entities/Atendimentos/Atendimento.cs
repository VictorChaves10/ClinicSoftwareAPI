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
        public virtual Cliente Cliente { get; set; }
        public virtual ICollection<AtendimentoProcedimento> Procedimentos { get; set; } = [];
        public virtual ICollection<PagamentoAtendimento> Pagamentos { get; set; } = [];

        public void AdicionarProcedimento(AtendimentoProcedimento procedimento)
        {
            Procedimentos.Add(procedimento);
        }

        public void RemoverProcedimento(AtendimentoProcedimento procedimento)
        {
            Procedimentos.Remove(procedimento);
        }
    }
}
