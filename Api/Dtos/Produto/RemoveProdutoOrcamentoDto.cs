using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api.Dtos.Produto
{
    public class RemoveProdutoOrcamentoDto
    {
        [JsonPropertyName("produtoid")]
        [Required(ErrorMessage = "Informe o Id do Produto")]
        public Guid Id { get; set; }
    }
}