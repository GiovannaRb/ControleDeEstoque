using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using ControleDeEstoque.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Application.Services
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

        public Task<string> AddProduto(ProdutoDto dados)
        {
            var produto = new Produto
            {
                Nome = dados.Nome,
                Quantidade = dados.Quantidade,
                Preco = dados.Preco,
                Categoria = dados.Categoria
            };
            return _repository.AddProduto(produto);
        }
        public Task<string> AtualizarProduto(ProdutoDto dados)
        {
            var produto = new Produto
            {
                Nome = dados.Nome,
                Quantidade = dados.Quantidade,
                Preco = dados.Preco,
                Categoria = dados.Categoria
            };

            return _repository.AtualizarProduto(produto);
        }

        public Task<string> DeletarProduto(int id)
        {
            return _repository.DeletarProduto(id);
        }
    }
}
