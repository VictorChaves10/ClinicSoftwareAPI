using ClinicSoftware.Domain.Entities.Funcionarios;
using ClinicSoftware.Domain.Entities.Procedimentos;
using System.Text.Json.Serialization;

namespace ClinicSoftware.Domain.Entities.Atendimentos
{
    public class AtendimentoXProcedimento
    {
        public long Id { get; set; }

        public long IdAtendimento { get; set; }

        public long IdProcedimento { get; set; }

        public long IdFuncionario { get; set; }

        public int Quantidade { get; set; }

        public decimal Subtotal { get; set; }

        [JsonIgnore]
        public virtual Atendimento Atendimento { get; set; }

        [JsonIgnore]
        public virtual Procedimento Procedimento { get; set; }
        
        [JsonIgnore]
        public virtual Funcionario Funcionario { get; set; }
    }
}
