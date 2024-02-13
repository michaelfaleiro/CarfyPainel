using System.ComponentModel.DataAnnotations;

namespace Api.Dtos.Orcamento
{
    public class UpdateOrcamentoDto
    {
        [Required(ErrorMessage = "Informe o Cliente")]
        public string Cliente { get; set; } = string.Empty;

        [Required(ErrorMessage = "Informe o Veículo")]
        public string Veiculo { get; set; } = string.Empty;

        public string? Placa { get; set; }
        public string? Chassi { get; set; }
    }
}