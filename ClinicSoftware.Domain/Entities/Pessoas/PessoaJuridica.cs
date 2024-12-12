using ClinicSoftware.Domain.Enums;

namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public class PessoaJuridica(string nome, string email, string telefone, string endereco, PessoaTipo pessoaTipo, string cnpj, string razaoSocial, string nomeFantasia) : Pessoa(nome, email, telefone, endereco, pessoaTipo)
    {
        public string CNPJ { get; private set; } = cnpj;
        public string RazaoSocial { get; private set; } = razaoSocial;
        public string NomeFantasia { get; private set; } = nomeFantasia;
    }

}
