using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Interfaces;
using ControleDeEstoque.Domain.Models.Dtos;
using ControleDeEstoque.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _service;
        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }

        [HttpGet("ListarProdutos")]
        public async Task<IActionResult> ListarProdutos()
        {
            var produtos =  await _service.ListarProdutos();
            return Ok(produtos);
        }

        [HttpPost("AddProduto")]
        public async Task<IActionResult> AddProduto([FromBody] ProdutoDto dados)
        {
            var retorno = await _service.AddProduto(dados);

            if (!retorno.IsSuccess)
                return BadRequest(retorno.Message);

            return Ok(retorno.Message);
        }

        [HttpPut("AtualizarProduto")]
        public async Task<IActionResult> AtualizarProduto([FromBody] ProdutoDto dados)
        {
            var retorno = await _service.AtualizarProduto(dados);

            if(!retorno.IsSuccess)
                return BadRequest(retorno.Message);

            return Ok(retorno.Message);
        }

        [HttpDelete("DeletarProduto")]
        public async Task<IActionResult> DeletarProduto(string Codigo)
        {
            var retorno = await _service.DeletarProduto(Codigo);

            if(!retorno.IsSuccess)
                return BadRequest(retorno.Message);

            return Ok(retorno.Message);
        }
    }
}
