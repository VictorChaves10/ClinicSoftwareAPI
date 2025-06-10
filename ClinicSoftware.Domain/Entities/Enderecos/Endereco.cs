namespace ClinicSoftware.Domain.Entities.Enderecos
{
    public class Endereco
    {
        public long Id { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public int Cep { get; set; }
        public string Complemento { get; set; }

        public Endereco()
        {
            
        }

        public Endereco(string rua, string bairro, string numero, string cidade, string estado, int cep, string complemento) : this()
        {
            Rua = rua;
            Bairro = bairro;
            Numero = numero;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            Complemento = complemento;            
        }
    }
}
