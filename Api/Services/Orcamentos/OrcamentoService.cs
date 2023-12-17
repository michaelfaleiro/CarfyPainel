using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Orcamentos
{
    public class OrcamentoService(DbApiContext context) : IOrcamentoService
    {
        private readonly DbApiContext _context = context;

        public async Task<Orcamento> CreateOrcamento(Orcamento orcamento)
        {

            await _context.Orcamentos.AddAsync(orcamento);
            await _context.SaveChangesAsync();

            return orcamento;
        }

        public async Task<Orcamento?> GetByIdOrcamento(Guid id)
        {

            var orcamento = await _context
            .Orcamentos
            .AsNoTracking()
            .Include(x => x.Produtos)
            .FirstOrDefaultAsync(x => x.Id == id);

            return orcamento;
        }

        public async Task<List<Orcamento>> GetOrcamentos(int take, int skip)
        {
            var orcamentos = await _context.Orcamentos
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
                .Include(x => x.Produtos)
                .ToListAsync();

            return orcamentos;
        }

        public async Task<bool> RemoveOrcamento(Orcamento orcamento)
        {
            _context.Remove(orcamento);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Orcamento?> AddProdutoOrcamento(Guid id, Produto produto)
        {
            var orcamento = await _context.Orcamentos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (orcamento is null)
            {
                return null;
            }

            orcamento.Produtos?.Add(produto);
            await _context.SaveChangesAsync();

            return orcamento;
        }

        public async Task<Produto?> RemoveProdutoOrcamento(Guid id)
        {
            var produto = await _context.Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto is null)
            {
                return null;
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();
            
            return produto;
        }
    }
}