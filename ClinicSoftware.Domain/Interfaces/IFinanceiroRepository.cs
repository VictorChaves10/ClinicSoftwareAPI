using ClinicSoftware.Domain.Entities.Financeiro;

namespace ClinicSoftware.Domain.Interfaces
{
    public interface IFinanceiroRepository
    {
        Task<PagamentoAtendimento> ObterPagamentoPorIdAsync(long id);
        Task<IEnumerable<PagamentoAtendimento>> ListarPagamentosAsync();
        Task<PagamentoAtendimento> AddPagamentoAsync(PagamentoAtendimento pagamento);
        PagamentoAtendimento AtualizarPagamento(PagamentoAtendimento pagamento);
        PagamentoAtendimento RemoverPagamento(PagamentoAtendimento pagamento);
    }
}
