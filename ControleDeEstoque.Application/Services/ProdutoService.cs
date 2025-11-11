using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using ControleDeEstoque.Domain.Interfaces;
using ControleDeEstoque.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IGenericRepository<Produto> _genericRepository;
        public ProdutoService(IGenericRepository<Produto> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Produto>> ListarProdutos()
        {  
           return await _genericRepository.GetAllAsync();
        }

        public async Task<Result> AddProduto(ProdutoDto dados)
        {
            if (dados.Codigo == null)
                return Result.Failure("Preencha o Codigo do produto!");

            var produto = new Produto
            {
                Codigo = dados.Codigo,
                Nome = dados.Nome,
                Quantidade = dados.Quantidade,
                Preco = dados.Preco,
                Categoria = dados.Categoria
            };

            var produtoExiste = await _genericRepository.GetAsync(p => p.Codigo == dados.Codigo);

            if (produtoExiste != null)
                return Result.Failure("Este produto já existe!");

            var addProduto = await _genericRepository.AddAsync(produto);

            if (addProduto is false)
            {
                return Result.Failure("Erro ao adicionar o produto!");
            }

            return Result.Success("Produto cadastrado com sucesso!");
        }
        public async Task<Result> AtualizarProduto(ProdutoDto dados)
        {
            var produto = new Produto
            {
                Codigo = dados.Codigo,
                Nome = dados.Nome,
                Quantidade = dados.Quantidade,
                Preco = dados.Preco,
                Categoria = dados.Categoria
            };

            var retorno = await _genericRepository.UpdateAsync(produto);

            if (retorno is false)
            {
                return Result.Failure("Erro ao atualizar produto!");

            }

            return Result.Failure("Produto atualizado com sucesso!");
        }

        public async Task<Result> DeletarProduto(string Codigo)
        {
            var produto = await _genericRepository.GetAsync(p => p.Codigo == Codigo);

            var retorno = await _genericRepository.DeleteAsync(produto);

            if (retorno is false)
            {
                return Result.Failure("Erro ao Deletar produto!");

            }

            return Result.Failure("Produto Deletado com sucesso!");
        }
    }
}
