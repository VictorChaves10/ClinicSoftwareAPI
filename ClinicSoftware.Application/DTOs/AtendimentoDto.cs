using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs
{
    public record AtendimentoDto
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "É obrigatório informar um cliente.")]
        public long IdCliente { get; set; }

        [Required(ErrorMessage = "A Data e Hora do Atendimento são obrigatórias.")]
        public DateTime DataHoraAtendimento { get; set; }

        [StringLength(500, ErrorMessage = "A Observação pode ter no máximo 500 caracteres.")]
        public string Observacao { get; set; }

        [MinLength(1, ErrorMessage = "Deve haver ao menos um pagamento.")]
        public List<PagamentoAtendimentoDto> Pagamentos { get; set; }      

        [MinLength(1, ErrorMessage = "Deve haver ao menos um procedimento.")]
        public List<AtendimentoProcedimentoDto> Procedimentos { get; set; }
    }
}
