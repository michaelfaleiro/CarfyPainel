using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Produto
{
    public class CreateProdutoDto
    {
        public string? Sku { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Produto")]
        public string NomeProduto { get; set; }
        public string? Marca { get; set; }
        public double PrecoCusto { get; set; } = 0;
        public double PrecoVenda { get; set; } = 0;
        public string? Link { get; set; }
        public string? Observacao { get; set; }
        [Required(ErrorMessage = "Id do Orcamento é Obrigatório!")]
        public Guid OrcamentoId { get; set; }
    }
}