using System.ComponentModel.DataAnnotations;

namespace ClinicSoftware.Application.DTOs
{
    public record AtendimentoProcedimentoDto
    {
        [Required(ErrorMessage = "O Id do Procedimento é obrigatório.")]
        public long Id { get; set; }

        [Required(ErrorMessage = "O Id do Atendimento é obrigatório.")]
        public long IdAtendimento { get; set; }

        [Required(ErrorMessage = "O Id do Procedimento é obrigatório.")]
        public long IdProcedimento { get; set; }

        [Required(ErrorMessage = "O Id do Funcionário é obrigatório.")]
        public long IdFuncionario { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser no mínimo 1.")]
        public int Quantidade { get; set; }
    }
}