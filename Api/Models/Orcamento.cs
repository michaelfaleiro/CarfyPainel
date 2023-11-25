namespace Api.Models
{
    public class Orcamento
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; }
        public string Veiculo { get; set; }
        public string? Placa { get; set; }
        public string? Chassi { get; set; }
        public List<Produto>? Produtos { get; set; } = [];
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;

    }
}