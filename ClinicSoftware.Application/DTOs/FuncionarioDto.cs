using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.Dtos
{
    public record FuncionarioDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; }
        
        [EmailAddress(ErrorMessage = "O e-mail não é válido.")]
        [StringLength(100, ErrorMessage = "O e-mail deve ter no máximo 150 caracteres.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "O número de telefone não é válido.")]
        [StringLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        [StringLength(250, ErrorMessage = "O endereço deve ter no máximo 250 caracteres.")]
        public string Endereco { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter exatamente 11 caracteres.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string CPF { get; set; }

        [DataType(DataType.Date, ErrorMessage = "A data de nascimento não é válida.")]
        public DateTime? DataNascimento { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "O salário base deve ser um valor positivo.")]
        [DataType(DataType.Currency)]
        public decimal? SalarioBase { get; set; }
    }
}
