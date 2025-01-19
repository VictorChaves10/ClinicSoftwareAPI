using ClinicSoftware.Domain.Entities.Financeiro;

namespace ClinicSoftware.Domain.Interfaces
{
    public interface IFinanceiroRepository
    {
        Task<Pagamento> ObterPagamentoPorIdAsync(long id);
        Task<IEnumerable<Pagamento>> ListarPagamentosAsync();
        Task<Pagamento> AddPagamentoAsync(Pagamento pagamento);
        Pagamento AtualizarPagamento(Pagamento pagamento);
        Pagamento RemoverPagamento(Pagamento pagamento);

        Task<Desconto> ObterDescontoPorIdAsync(long id);
        Task<IEnumerable<Desconto>> ListarDescontosAsync();
        Task<Desconto> AddDescontoAsync(Desconto desconto);
        Desconto AtualizarDesconto(Desconto desconto);
        Desconto RemoverDesconto(Desconto desconto);

    }
}
