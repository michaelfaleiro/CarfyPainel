using Api.Dtos.Orcamento;
using Api.Dtos.Produto;
using Api.Extensions;
using Api.Models;
using Api.Services.Orcamentos;
using Api.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    public class OrcamentoController(IMapper mapper, IOrcamentoService orcamentoService) : ControllerBase
    {
        private readonly IMapper _mapper = mapper;
        private readonly IOrcamentoService _service = orcamentoService;


        [HttpPost("v1/api/orcamentos")]
        public async Task<ActionResult<Orcamento>> CriarOrcamentoAsync([FromBody] CreateOrcamentoDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Orcamento>(ModelState.GetErrors()));

            Orcamento orcamento = _mapper.Map<Orcamento>(model);

            try
            {
                await _service.CriarOrcamento(orcamento);

                return Created($"v1/api/orcamentos/{orcamento.Id}", new ResultViewModel<Orcamento>(orcamento));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao Salvar!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
            }
        }

        [HttpPost("v1/api/orcamentos/{id:Guid}/adicionarproduto")]
        public async Task<ActionResult<Orcamento>> AdicionarProdutoOrcamentoAsync(
            [FromRoute] Guid id,
            [FromBody] CreateProdutoDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Orcamento>(ModelState.GetErrors()));

            var produto = _mapper.Map<Produto>(model);

            try
            {
                var orcamento = await _service.AdicionarProdutoOrcamento(id, produto);
                if (orcamento is null)
                    return NotFound(new ResultViewModel<Orcamento>("Orcamento não encontrado"));

                return Ok(orcamento);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao Adicionar Produto!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Produto>("Falha Interna no Servidor"));
            }
        }

        [HttpGet("v1/api/orcamentos")]
        public async Task<ActionResult<IEnumerable<Orcamento>>> BuscarOrcamentosAsync([FromQuery] int take = 100, int skip = 0)
        {
            try
            {
                var orcamentos = await _service.BuscarOrcamentos(take, skip);

                return Ok(new ResultViewModel<List<Orcamento>>(orcamentos));

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao Buscar Dados!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
            }
        }

        [HttpGet("v1/api/orcamentos/{id:guid}")]
        public async Task<ActionResult<Orcamento>> BuscarOrcamentoIdAsync(Guid id)
        {
            try
            {
                var orcamento = await _service.BuscarOrcamentoId(id);

                if (orcamento == null)
                    return NotFound(new ResultViewModel<Orcamento>("Orçamento não encontrado"));

                return Ok(new ResultViewModel<dynamic>(orcamento));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao Buscar Dados!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
            }
        }

        [HttpGet("v1/api/orcamentos/{produtoId:guid}/produtos")]
        public async Task<IActionResult> BuscarProdutoIdAsync(Guid produtoId)
        {
            try
            {
                var produto = await _service.BuscarProdutoId(produtoId);

                if (produto is null)
                    return StatusCode(404, new ResultViewModel<Produto>("Produto não encontrado"));

                return Ok(new ResultViewModel<dynamic>(produto));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Não foi possível buscar os dados!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
            }
        }

        [HttpPut("v1/api/orcamentos/{id:guid}")]
        public async Task<ActionResult> EditarOrcamentoAsync([FromRoute] Guid id, [FromBody] CreateOrcamentoDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Orcamento>(ModelState.GetErrors()));

            try
            {
                var orcamento = await _service.BuscarOrcamentoId(id);

                if (orcamento is null)
                    return StatusCode(404, new ResultViewModel<Orcamento>("Orcamento não encontrado"));

                _mapper.Map(model, orcamento);

                await _service.EditarOrcamento(orcamento);

                return Ok(new ResultViewModel<dynamic>(orcamento));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao Salvar Alterações!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
            }
        }

        [HttpPut("v1/api/orcamentos/{id:guid}/editarproduto")]

        public async Task<IActionResult> EditarProdutoOrcamentoAsync(Guid id, CreateProdutoDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Produto>(ModelState.GetErrors()));

            try
            {
                var produto = await _service.BuscarProdutoId(id);

                if (produto is null)
                    return StatusCode(404, new ResultViewModel<Produto>("Produto não encontrado"));

                _mapper.Map(model, produto);

                await _service.EditarProdutoOrcamento(produto);

                return Ok(new ResultViewModel<dynamic>(produto));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Erro ao Salvar Alterações!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Orcamento>("Falha Interna no Servidor"));
            }

        }

        [HttpDelete("v1/api/orcamentos/{id:guid}")]
        public async Task<ActionResult> DeletarOrcamentoAsync(Guid id)
        {
            try
            {
                var orcamento = await _service.BuscarOrcamentoId(id);

                if (orcamento is null)
                {
                    return NotFound("Orçamento não encontrado");
                }

                await _service.DeletarOrcamento(orcamento);

                return NoContent();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao Deletar Produto!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Produto>("Falha Interna no Servidor"));
            }
        }

        [HttpDelete("v1/api/orcamentos/{id:guid}/{produtoId:guid}")]
        public async Task<ActionResult> RemoverProdutoOrcamentoAsync([FromRoute] Guid id, [FromRoute] Guid produtoId)
        {
            try
            {
                var orcamento = await _service.BuscarOrcamentoId(id);

                if (orcamento is null)
                    return NotFound(new ResultViewModel<Orcamento>("Orçamento não encontrado"));

                if (!orcamento.Produtos!.Any(x => x.Id == produtoId))
                    return NotFound(new ResultViewModel<Orcamento>("Produto não encontrado"));

                await _service.RemoverProdutoOrcamento(produtoId);

                return Ok(new ResultViewModel<Produto>("Excluído com Sucesso"));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultViewModel<Produto>("Erro ao Excluir Produto!"));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Produto>("Falha Interna no Servidor"));
            }
        }
    }
}