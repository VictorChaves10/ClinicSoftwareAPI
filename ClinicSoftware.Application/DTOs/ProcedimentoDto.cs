using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs
{
    public record ProcedimentoDto
    {
        [Required]
        public long Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "O nome do procedimento não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        [StringLength(250, ErrorMessage = "A descrição não pode ter mais de 250 caracteres.")]
        public string Descricao { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }
    }
}
