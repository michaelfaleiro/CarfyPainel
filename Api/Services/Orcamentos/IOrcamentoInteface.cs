using Api.Models;

namespace Api.Services.Orcamentos
{
    public interface IOrcamentoInteface
    {
        Task<Orcamento> CreateOrcamento(Orcamento orcamento);
        Task<List<Orcamento>> GetOrcamentos(int take, int skip);
        Task<Orcamento?> GetByIdOrcamento(Guid id);
        Task<bool> RemoveOrcamento(Orcamento orcamento);
        Task<Orcamento?> AddProdutoOrcamento(Guid id, Produto produto);
        Task<Produto?> RemoveProdutoOrcamento(Guid id);
    }
}