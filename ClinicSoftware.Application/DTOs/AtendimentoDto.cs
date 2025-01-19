using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs
{
    public record AtendimentoDto
    {
        [Required(ErrorMessage = "O Id é obrigatório.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O Id do Cliente é obrigatório.")]
        public long IdCliente { get; set; }

        [Required(ErrorMessage = "A Data e Hora do Atendimento são obrigatórias.")]
        public DateTime DataHoraAtendimento { get; set; }

        [StringLength(500, ErrorMessage = "A Observação pode ter no máximo 500 caracteres.")]
        public string Observacao { get; set; }

        [Required(ErrorMessage = "O pagamento é obrigatório.")]
        public PagamentoDto Pagamento { get; set; }

        [Required(ErrorMessage = "Ao menos um procedimento é obrigatório.")]
        [MinLength(1, ErrorMessage = "Deve haver ao menos um procedimento.")]
        public List<AtendimentoProcedimentoDto> Procedimentos { get; set; }
    }
}
