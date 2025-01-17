using ClinicSoftware.Domain.Entities.Financeiro;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class Atendimento
    {
        public long Id { get; set; }
        public long IdCliente { get; set; }
        public DateTime DataHoraAtendimento { get; set; }
        public FormaDePagamentoEnum FormaDePagamento { get; set; }
        public DateTime DataResgistro { get; set; }
    }
}
