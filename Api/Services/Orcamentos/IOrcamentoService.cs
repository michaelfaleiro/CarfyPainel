using Api.Models;

namespace Api.Services.Orcamentos
{
    public interface IOrcamentoService
    {
        Task<Orcamento> CriarOrcamento(Orcamento orcamento);
        Task<List<Orcamento>> BuscarOrcamentos(int take, int skip);
        Task<Orcamento?> BuscarOrcamentoId(Guid id);
        Task<Produto?> BuscarProdutoId(Guid id);
        Task<Orcamento> EditarOrcamento(Orcamento orcamento);
        Task<Orcamento?> AdicionarProdutoOrcamento(Guid id, Produto produto);
        Task<Produto> EditarProdutoOrcamento(Produto produto);
        Task<Produto?> RemoverProdutoOrcamento(Guid id);
        Task<Orcamento> DeletarOrcamento(Orcamento orcamento);
    }
}