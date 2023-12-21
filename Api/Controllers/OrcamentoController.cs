using Api.Dtos.Orcamento;
using Api.Dtos.Produto;
using Api.Extensions;
using Api.Models;
using Api.Services.Orcamentos;
using Api.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<ActionResult<Orcamento>> CreateOrcamentoAsync([FromBody] CreateOrcamentoDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Orcamento>(ModelState.GetErrors()));
            }

            Orcamento orcamento = _mapper.Map<Orcamento>(model);

            try
            {
                await _service.CreateOrcamento(orcamento);

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

        [HttpPost("v1/api/orcamentos/addproduto")]
        public async Task<ActionResult<Orcamento>> AddProdutoOrcamentoAsync([FromBody] CreateProdutoDto model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new ResultViewModel<Orcamento>(ModelState.GetErrors()));
            }

            var produto = _mapper.Map<Produto>(model);


            try
            {
                var orcamento = await _service.AddProdutoOrcamento(model.OrcamentoId, produto);
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
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetOrcamentosAsync([FromQuery] int take = 100, int skip = 0)
        {
            try
            {
                var orcamentos = await _service.GetOrcamentos(take, skip);

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
        public async Task<ActionResult<Orcamento>> GetByIdOrcamentoAsync(Guid id)
        {
            try
            {
                var orcamento = await _service.GetByIdOrcamento(id);

                if (orcamento == null)
                {
                    return NotFound(new ResultViewModel<Orcamento>("Orçamento não encontrado"));
                }

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

        [HttpDelete("v1/api/orcamentos/{id:guid}")]
        public async Task<ActionResult> RemoveOrcamentoAsync(Guid id)
        {
            try
            {
                var orcamento = await _service.GetByIdOrcamento(id);

                if (orcamento is null)
                {
                    return NotFound("Orçamento não encontrado");
                }

                await _service.RemoveOrcamento(orcamento);

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

        [HttpDelete("v1/api/orcamentos/removeproduto/{id:guid}")]
        public async Task<ActionResult> RemoveProdutoOrcamentoAsync([FromRoute] Guid id)
        {
            try
            {
                var orcamento = await _service.RemoveProdutoOrcamento(id);

                if (orcamento is null)
                    return NotFound(new ResultViewModel<Orcamento>("Orçamento não encontrado"));

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