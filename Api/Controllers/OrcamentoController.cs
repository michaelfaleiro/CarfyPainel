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
    public class OrcamentoController(IMapper mapper, IOrcamentoInteface orcamentoInteface) : ControllerBase
    {

        private readonly IMapper _mapper = mapper;
        private readonly IOrcamentoInteface _service = orcamentoInteface;

        [HttpPost("v1/api/orcamentos")]
        public async Task<ActionResult> CreateOrcamento([FromBody] CreateOrcamentoDto model)
        {
            Orcamento orcamento = _mapper.Map<Orcamento>(model);

            try
            {
                await _service.CreateOrcamento(orcamento);
                return Created($"~v1/api/orcamentos/{orcamento.Id}", orcamento);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, ("Não foi possível Salvar!"));
            }
            catch
            {
                return StatusCode(500, ("Falha Interna no Servidor"));
            }
        }

        [HttpGet("v1/api/orcamentos")]
        public async Task<ActionResult> GetOrcamentos([FromQuery] int take = 25, int skip = 0)
        {
            try
            {
                var orcamentos = await _service.GetOrcamentos(take, skip);

                return Ok(orcamentos);
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, ("Não foi possível Buscar os Dados!"));
            }
            catch
            {
                return StatusCode(500, ("Falha Interna no Servidor"));
            }
        }

        [HttpGet("v1/api/orcamentos/{id:guid}")]
        public async Task<ActionResult> GetByIdOrcamento(Guid id)
        {
            try
            {
                var orcamento = await _service.GetByIdOrcamento(id);

                if (orcamento is null)
                {
                    return NotFound("Orcamento não encontrado");
                }

                return Ok(orcamento);

            }
            catch (DbUpdateException)
            {
                return StatusCode(500, ("Não foi possível Buscar os Dados!"));
            }
            catch
            {
                return StatusCode(500, ("Falha Interna no Servidor"));
            }
        }

        [HttpPost("v1/api/orcamentos/addproduto")]
        public async Task<ActionResult> AddProdutoOrcamento([FromBody] CreateProdutoDto model)
        {

            var produto = _mapper.Map<Produto>(model);

            var orcamento = await _service.AddProdutoOrcamento(produto.OrcamentoId, produto);

            return Ok(orcamento);
        }
    }
}