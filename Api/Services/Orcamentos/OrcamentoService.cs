using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
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

        public async Task<Orcamento> GetByIdOrcamento(Guid id)
        {
            return await _context.Orcamentos.FirstOrDefaultAsync(x => x.Id == id);

        }

        public async Task<List<Orcamento>> GetOrcamentos(int take, int skip)
        {
            return await _context.Orcamentos.Include(x => x.Produtos).AsNoTracking().Skip(skip).Take(take).ToListAsync();
        }

        public async Task<Orcamento> AddProdutoOrcamento(Guid id, Produto produto)
        {
            var orcamento = await _context.Orcamentos.FirstOrDefaultAsync(x => x.Id == id);

            if (orcamento is not null)
            {
                orcamento.Produtos.Add(produto);

                await _context.SaveChangesAsync();

                return orcamento;
            }
            return null;
        }
    }
}