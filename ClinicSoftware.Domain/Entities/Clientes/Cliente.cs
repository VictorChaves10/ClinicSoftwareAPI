using ClinicSoftware.Domain.Entities.Pessoas;

namespace ClinicSoftware.Domain.Entities.Cliente
{
    public class Cliente(long pessoaId)
    {
        public long Id { get; private set; }
        public long PessoaId { get; private set; } = pessoaId;
        public Pessoa Pessoa { get; private set; }
        public DateTime DataCadastro { get; private set; } = DateTime.Now;
    }
}
