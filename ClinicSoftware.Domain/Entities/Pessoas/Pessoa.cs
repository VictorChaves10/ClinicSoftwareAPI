using ClinicSoftware.Domain.Enums;

namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public abstract class Pessoa(string nome, string email, string telefone, string endereco, PessoaTipo pessoaTipo)
    {
        public long Id { get; private set; }
        public string Nome { get; private set; } = nome;
        public string Email { get; private set; } = email;
        public string Telefone { get; private set; } = telefone;
        public string Endereco { get; private set; } = endereco;
        public PessoaTipo Tipo { get; private set; } = pessoaTipo;
    }

}
