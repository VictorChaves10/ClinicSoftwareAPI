using ClinicSoftware.Domain.Enums;

namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public class PessoaFisica(string nome, string email, string telefone, string endereco,
                       PessoaTipo pessoaTipo, string cpf, DateTime dataNascimento) : Pessoa(nome, email, telefone, endereco, pessoaTipo)
    {
        public string CPF { get; private set; } = cpf;
        public DateTime DataNascimento { get; private set; } = dataNascimento;
    }

}
