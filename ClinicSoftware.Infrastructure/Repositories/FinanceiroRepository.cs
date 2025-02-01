using ClinicSoftware.Domain.Entities.Financeiro;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicSoftware.Infrastructure.Repositories
{
    public class FinanceiroRepository : IFinanceiroRepository
    {

        private readonly ApplicationDbContext _context;

        public FinanceiroRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PagamentoAtendimento> ObterPagamentoPorIdAsync(long id)
        {
            return await _context.PagamentosAtendimentos.FindAsync(id);
        }
        public async Task<IEnumerable<PagamentoAtendimento>> ListarPagamentosAsync()
        {
            return await _context.PagamentosAtendimentos.AsNoTracking()
                                            .ToListAsync();
        }
        public async Task<PagamentoAtendimento> AddPagamentoAsync(PagamentoAtendimento pagamento)
        {
            await _context.PagamentosAtendimentos.AddAsync(pagamento);
            return pagamento;
        }
        public PagamentoAtendimento AtualizarPagamento(PagamentoAtendimento pagamento)
        {
            _context.PagamentosAtendimentos.Update(pagamento);
            return pagamento;
        }

        public PagamentoAtendimento RemoverPagamento(PagamentoAtendimento pagamento)
        {
            _context.PagamentosAtendimentos.Remove(pagamento);
            return pagamento;
        }

    }


}
