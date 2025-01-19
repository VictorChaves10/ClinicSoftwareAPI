using ClinicSoftware.Domain.Entities.Atendimentos;
using ClinicSoftware.Domain.Interfaces;
using ClinicSoftware.Infrastructure.Context;

namespace ClinicSoftware.Infrastructure.Repositories
{
    public class AtendimentoRepository : IAtendimentoRepository
    {
        private readonly ApplicationDbContext _context;

        public AtendimentoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Atendimento> AddAtendimentoAsync(Atendimento atendimento)
        {
            await _context.Atendimentos.AddAsync(atendimento);
            return atendimento;
        }

        public async Task<Atendimento> ObterAtendimentoPorIdAsync(long id)
        {
            var atendimento = await _context.Atendimentos.FindAsync(id);
            return atendimento;
        }
    }
}
