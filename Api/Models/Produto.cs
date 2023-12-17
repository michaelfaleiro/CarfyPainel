namespace Api.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
        public string? Sku { get; set; }
        public string NomeProduto { get; set; } = string.Empty;
        public string? Marca { get; set; }
        public double PrecoCusto { get; set; } = 0;
        public double PrecoVenda { get; set; } = 0;
        public string? Link { get; set; }
        public string? Observacao { get; set; }
        public Orcamento? Orcamento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }
}