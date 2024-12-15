using ClinicSoftware.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs;

public class ClienteDto
{
    public long Id { get; set; }

    // Dados da pessoa
    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(100, ErrorMessage = "O campo Nome deve ter no máximo 100 caracteres.")]
    public string Nome { get; set; }
    
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [Phone(ErrorMessage = "O campo Telefone deve conter um número válido.")]
    public string Telefone { get; set; }

    [StringLength(200, ErrorMessage = "O campo Endereço deve ter no máximo 200 caracteres.")]
    public string Endereco { get; set; }

    [Required(ErrorMessage = "O campo PessoaTipo é obrigatório.")]
    public PessoaTipo PessoaTipo { get; set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
    public string CPF { get; set; }

    [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter exatamente 14 caracteres.")]
    [RegularExpression(@"^\d{14}$", ErrorMessage = "O CNPJ deve conter apenas números.")]
    public string CNPJ { get; set; }

    [StringLength(150, ErrorMessage = "O campo Razão Social deve ter no máximo 150 caracteres.")]
    public string RazaoSocial { get; set; }

    [StringLength(150, ErrorMessage = "O campo Nome Fantasia deve ter no máximo 150 caracteres.")]
    public string NomeFantasia { get; set; } 

    [DataType(DataType.Date, ErrorMessage = "A Data de Nascimento deve ser uma data válida.")]
    public DateTime? DataNascimento { get; set; }
}
