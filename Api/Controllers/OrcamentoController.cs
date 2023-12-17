using Api.Dtos.Orcamento;
using Api.Dtos.Produto;
using Api.Models;
using Api.Services.Orcamentos;
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
        public async Task<ActionResult<Orcamento>> CreateOrcamentoAsync([FromBody] CreateOrcamentoDto model)
        {
            Orcamento orcamento = _mapper.Map<Orcamento>(model);

            try
            {
                await _service.CreateOrcamento(orcamento);

                return Created($"v1/api/orcamentos/{orcamento.Id}", orcamento);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Não foi possível Salvar!");
            }
            catch
            {
                return StatusCode(500, "Falha Interna no Servidor");
            }
        }

        [HttpGet("v1/api/orcamentos")]
        public async Task<ActionResult<IEnumerable<Orcamento>>> GetOrcamentosAsync([FromQuery] int take = 100, int skip = 0)
        {
            try
            {
                var orcamentos = await _service.GetOrcamentos(take, skip);

                return Ok(orcamentos);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Não foi possível Buscar os Dados!");
            }
            catch
            {
                return StatusCode(500, "Falha Interna no Servidor");
            }
        }

        [HttpGet("v1/api/orcamentos/{id:guid}")]
        public async Task<ActionResult<Orcamento>> GetByIdOrcamentoAsync(Guid id)
        {
            try
            {
                var orcamento = await _service.GetByIdOrcamento(id);

                if (orcamento is null)
                {
                    return NotFound("Orçamento não encontrado");
                }

                return Ok(orcamento);

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Não foi possível Buscar os Dados!");
            }
            catch
            {
                return StatusCode(500, "Falha Interna no Servidor");
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
                return StatusCode(500, "Erro ao remover Orcamento!");
            }
            catch
            {
                return StatusCode(500, "Falha Interna no Servidor");
            }
        }

        [HttpPost("v1/api/orcamentos/{id:guid}/addproduto")]
        public async Task<ActionResult<Orcamento>> AddProdutoOrcamentoAsync([FromRoute] Guid id ,[FromBody] CreateProdutoDto model)
        {
            var produto = _mapper.Map<Produto>(model);

            try
            {
                var orcamento = await _service.AddProdutoOrcamento(id, produto);

                return Ok(orcamento);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Não foi possível Adicionar o Produto!");
            }
            catch
            {
                return StatusCode(500, "Falha Interna no Servidor");
            }
        }

        [HttpDelete("v1/api/orcamentos/removeproduto/{id:guid}")]

        public async Task<ActionResult> RemoveProdutoOrcamentoAsync([FromRoute] Guid id)
        {

            try
            {
                await _service.RemoveProdutoOrcamento(id);

                return NoContent();
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, "Não foi possível Remover o Produto!");
            }
            catch
            {
                return StatusCode(500, "Falha Interna no Servidor");
            }

        }
    }
}