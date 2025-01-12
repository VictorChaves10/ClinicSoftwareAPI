namespace ClinicSoftware.Domain.Entities.Procedimentos
{
    public class Procedimento
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
    }
}
