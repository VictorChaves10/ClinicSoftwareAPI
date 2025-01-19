using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs
{
    public class PagamentoDto
    {
        [Required(ErrorMessage = "O valor do pagamento é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O valor do pagamento deve ser maior que 0.")]
        public decimal Valor { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        [StringLength(50, ErrorMessage = "A forma de pagamento pode ter no máximo 50 caracteres.")]
        public string FormaDePagamento { get; set; }
    }
}
