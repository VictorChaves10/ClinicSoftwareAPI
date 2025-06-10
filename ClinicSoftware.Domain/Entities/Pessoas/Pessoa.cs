using ClinicSoftware.Domain.Entities.Enderecos;

namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public abstract class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
    }
}
