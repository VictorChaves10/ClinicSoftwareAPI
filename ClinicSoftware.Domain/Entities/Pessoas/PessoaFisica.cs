namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public class PessoaFisica : Pessoa
    {
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
    }
}
