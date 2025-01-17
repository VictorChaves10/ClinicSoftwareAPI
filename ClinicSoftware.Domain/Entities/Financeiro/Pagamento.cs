namespace ClinicSoftware.Domain.Entities.Financeiro
{
    public class Pagamento
    {
        public long Id { get; set; }
        public FormaPagamentoEnum FormaDePagamento { get; set; }
        public decimal Valor { get; set; }
    }
}
