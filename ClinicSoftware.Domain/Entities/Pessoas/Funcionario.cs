namespace ClinicSoftware.Domain.Entities.Pessoas
{
    public class Funcionario : PessoaFisica
    {
        public long? Matricula { get; set; }
        public decimal? SalarioBase { get; private set; }
    }
}
