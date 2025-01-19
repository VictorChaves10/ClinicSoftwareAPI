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

        public async Task<Pagamento> ObterPagamentoPorIdAsync(long id)
        {
            return await _context.Pagamentos.FindAsync(id);
        }
        public async Task<IEnumerable<Pagamento>> ListarPagamentosAsync()
        {
            return await _context.Pagamentos.AsNoTracking()
                                            .ToListAsync();
        }
        public async Task<Pagamento> AddPagamentoAsync(Pagamento pagamento)
        {
            await _context.Pagamentos.AddAsync(pagamento);
            return pagamento;
        }
        public Pagamento AtualizarPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Update(pagamento);
            return pagamento;
        }

        public Pagamento RemoverPagamento(Pagamento pagamento)
        {
            _context.Pagamentos.Remove(pagamento);
            return pagamento;
        }

        public async Task<Desconto> ObterDescontoPorIdAsync(long id)
        {
            return await _context.Descontos.FindAsync(id);
        }
        public async Task<IEnumerable<Desconto>> ListarDescontosAsync()
        {
            return await _context.Descontos.AsNoTracking()
                                           .ToListAsync();
        }

        public async Task<Desconto> AddDescontoAsync(Desconto desconto)
        {
            await _context.Descontos.AddAsync(desconto);
            return desconto;
        }

        public Desconto AtualizarDesconto(Desconto desconto)
        {
            _context.Descontos.Update(desconto);
            return desconto;
        }

        public Desconto RemoverDesconto(Desconto desconto)
        {
            _context.Descontos.Remove(desconto);
            return desconto;
        }

    }


}
