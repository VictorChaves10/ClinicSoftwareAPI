namespace ClinicSoftware.Domain.Entities.Clientes;

public class Cliente
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Endereco { get; private set; }
    public string CPF { get; private set; }
    public DateTime? DataNascimento { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Cliente() { }

    public void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentException("O nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(Telefone))
            throw new ArgumentException("O telefone é obrigatório.");

        if (DataCadastro == default)
            DataCadastro = DateTime.Now;
    }

    public void Atualizar(string nome, string email, string telefone, string endereco, string cpf, DateTime? datanascimento)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        CPF = cpf;

        if (datanascimento.HasValue)
        {
            DataNascimento = datanascimento.Value;
        }
    }
}
