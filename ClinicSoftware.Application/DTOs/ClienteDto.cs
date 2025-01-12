using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs;

public record ClienteDto
{
    public long Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório.")]
    [StringLength(150, ErrorMessage = "O campo Nome deve ter no máximo 150 caracteres.")]
    public string Nome { get; set; }

    [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
    [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 100 caracteres.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
    [Phone(ErrorMessage = "O campo Telefone deve conter um número válido.")]
    public string Telefone { get; set; }

    [StringLength(250, ErrorMessage = "O campo Endereço deve ter no máximo 250 caracteres.")]
    public string Endereco { get; set; }

    [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
    public string CPF { get; set; }

    [DataType(DataType.Date, ErrorMessage = "A Data de Nascimento deve ser uma data válida.")]
    public DateTime? DataNascimento { get; set; }
}
