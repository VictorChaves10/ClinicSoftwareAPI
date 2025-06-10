namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public class Cliente : PessoaFisica
    {
        public DateTime DataCadastro { get; private set; }
    }
}
