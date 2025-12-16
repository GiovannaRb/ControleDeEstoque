using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Interfaces;
using ControleDeEstoque.Domain.Models.Dtos;
using ControleDeEstoque.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _service;
        public CategoriaController(ICategoriaService service)
        {
            _service = service;
        }

        [HttpGet("ListarCategorias")]
        public async Task<IActionResult> ListarCategorias()
        {
            var categorias =  await _service.ListarCategorias();
            return Ok(categorias);
        }

        [HttpPost("AddCategoria")]
        public async Task<IActionResult> AddCategoria([FromBody] CategoriaDto dados)
        {
            var retorno = await _service.AddCategoria(dados);

            if (!retorno.IsSuccess)
                return BadRequest(retorno.Message);

            return Ok(retorno.Message);
        }

        [HttpPut("AtualizarCategoria")]
        public async Task<IActionResult> AtualizarCategoria([FromBody] CategoriaDto dados)
        {
            var retorno = await _service.AtualizarCategoria(dados);

            if(!retorno.IsSuccess)
                return BadRequest(retorno.Message);

            return Ok(retorno.Message);
        }

        [HttpDelete("DeletarCategoria")]
        public async Task<IActionResult> DeletarCategoria([FromBody] string Nome)
        {
            var retorno = await _service.DeletarCategoria(Nome);

            if(!retorno.IsSuccess)
                return BadRequest(retorno.Message);

            return Ok(retorno.Message);
        }
    }
}
