using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly IEstoqueService _service;
        public EstoqueController(IEstoqueService service)
        {
            _service = service;
        }

        [HttpGet]
        public Task<List<Produto>> ListarProdutos()
        {
          return _service.ListarProdutos();
        }

        [HttpPost]
        public Task<string> AddProduto(Produto dados)
        {
            return _service.AddProduto(dados);
        }

        [HttpPut]
        public Task<string> AtualizarProduto(Produto dados)
        {
            return _service.AtualizarProduto(dados);
        }

        [HttpDelete]
        public Task<string> DeletarProduto(int id)
        {
            return _service.DeletarProduto(id);
        }
    }
}
