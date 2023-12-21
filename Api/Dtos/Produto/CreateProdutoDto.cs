using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Produto
{
    public class CreateProdutoDto
    {
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que 0")]
        public int Quantidade { get; set; }

        public string? Sku { get; set; }

        [Required(ErrorMessage = "Informe o Nome do Produto")]
        public string NomeProduto { get; set; } = string.Empty;

        public string? Marca { get; set; }
        public double PrecoCusto { get; set; } = 0;
        public double PrecoVenda { get; set; } = 0;
        public Guid OrcamentoId { get; set; } = Guid.Empty;
        public string? Link { get; set; }
        public string? Observacao { get; set; }
    }
}