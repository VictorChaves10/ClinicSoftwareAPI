using ClinicSoftware.Domain.Entities.Atendimentos;

namespace ClinicSoftware.Domain.Entities.Financeiro;

public class PagamentoAtendimento
{
    public long Id { get; set; }
    public long IdAtendimento { get; set; }
    public decimal ValorPago { get; set; }
    public FormaPagamentoEnum FormaPagamento { get; set; } 
    public virtual Atendimento Atendimento { get; set; }
}
