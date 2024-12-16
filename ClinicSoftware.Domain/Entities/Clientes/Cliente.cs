namespace ClinicSoftware.Domain.Entities.Cliente;

public class Cliente
{
    public long Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Endereco { get; private set; }

    // Dados específicos para pessoa física
    public string CPF { get; private set; }
    public DateTime? DataNascimento { get; private set; }

    private Cliente() { }

    // Construtor para Pessoa Física
    public Cliente(string nome, string email, string telefone, string endereco, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        CPF = cpf;
        DataNascimento = dataNascimento;

        Validar();
    }

    private void Validar()
    {
        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentException("O nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(Nome))
            throw new ArgumentException("O nome é obrigatório.");

        if (string.IsNullOrWhiteSpace(Telefone))
            throw new ArgumentException("O telefone é obrigatório.");
    }

    // Atualização de dados
    public void AtualizarDados(string nome, string email, string telefone, string endereco, string cpf, DateTime dataNascimento)
    {
        Nome = nome;
        Email = email;
        Telefone = telefone;
        Endereco = endereco;
        CPF = cpf;
        DataNascimento = dataNascimento;

        Validar();
    }
}
