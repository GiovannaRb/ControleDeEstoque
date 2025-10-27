using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.API.Services
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IEstoqueRepository _repository;
        public EstoqueService(IEstoqueRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<Produto>> ListarProdutos()
        {
           return _repository.ListarProdutos();
        }

        public Task<string> AddProduto(Produto dados)
        {
            return _repository.AddProduto(dados);
        }
        public Task<string> AtualizarProduto(Produto dados)
        {
            return _repository.AtualizarProduto(dados);
        }

        public Task<string> DeletarProduto(int id)
        {
            return _repository.DeletarProduto(id);
        }
    }
}
