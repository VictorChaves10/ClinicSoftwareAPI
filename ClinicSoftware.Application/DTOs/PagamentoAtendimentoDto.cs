using ClinicSoftware.Domain.Entities.Financeiro;
using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs
{
    public record PagamentoAtendimentoDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O Id do Atendimento é obrigatório.")]
        public long IdAtendimento { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "O valor pago deve ser maior que zero.")]
        public decimal ValorPago { get; set; }

        [Required(ErrorMessage = "A forma de pagamento é obrigatória.")]
        public FormaPagamentoEnum FormaPagamento { get; set; }

    }
}
