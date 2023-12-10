using Api.Data;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Services.Orcamentos
{
    public class OrcamentoService(DbApiContext context) : IOrcamentoInteface
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

            Orcamento? orcamento = await _context
            .Orcamentos
            .Include(x => x.Produtos)
            .FirstOrDefaultAsync(x => x.Id == id);

            return orcamento;

        }

        public async Task<List<Orcamento>> GetOrcamentos(int take, int skip)
        {
            List<Orcamento> orcamentos = await _context.Orcamentos
                .Include(x => x.Produtos)
                .AsNoTracking()
                .Skip(skip)
                .Take(take)
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
            Orcamento? orcamento = await _context.Orcamentos
                .Include(x => x.Produtos)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (orcamento is not null)
            {
                orcamento.Produtos?.Add(produto);

                await _context.SaveChangesAsync();

                return orcamento;
            }

            return null;
        }


        async Task<Produto?> IOrcamentoInteface.RemoveProdutoOrcamento(Guid id)
        {
            Produto? produto = await _context.Produtos
                .FirstOrDefaultAsync(x => x.Id == id);

            if (produto is not null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
                return produto;
            }

            return null;
        }


    }
}