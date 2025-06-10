using ClinicSoftware.Domain.Entities.Enderecos;

namespace ClinicSoftware.Domain.Entities.Funcionarios
{
    public class Funcionario
    {
        public long Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Telefone { get; private set; }
        public Endereco Endereco { get; private set; }
        public string CPF { get; private set; }
        public DateTime? DataNascimento { get; private set; }
        public decimal? SalarioBase { get; private set; }
    }
}
