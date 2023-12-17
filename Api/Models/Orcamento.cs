namespace Api.Models
{
    public class Orcamento
    {
        public Guid Id { get; set; }
        public string Cliente { get; set; } = string.Empty;
        public string Veiculo { get; set; } = string.Empty;
        public string? Placa { get; set; }
        public string? Chassi { get; set; }
        public IList<Produto>? Produtos { get; set; } = [];
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}