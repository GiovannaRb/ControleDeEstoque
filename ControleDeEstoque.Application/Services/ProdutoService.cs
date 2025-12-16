using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Interfaces;
using ControleDeEstoque.Domain.Models.Dtos;
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

        public async Task<IEnumerable<ProdutoDto>> ListarProdutos()
        {  
           var listaProdutos = await _genericRepository.GetAllAsync();

            var retorno = listaProdutos.Select(p => new ProdutoDto
            { 
                Codigo = p.Codigo,
                Nome = p.Nome,
                Descricao = p.Descricao,
                Quantidade = p.Quantidade,
                Preco = p.Preco,
                Categoria = p.Categoria
            });

            return retorno;
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
            var categoriaExiste = await _genericRepository.GetAsync(p => p.Nome == dados.Nome);

            if (categoriaExiste == null)
                return Result.Failure("Produto não encontrado!");

            if (dados.Codigo != null)
                categoriaExiste.Codigo = dados.Codigo;

            if (dados.Nome != null)
                categoriaExiste.Nome = dados.Nome;

            if (dados.Descricao != null)
                categoriaExiste.Descricao = dados.Descricao;

            if (dados.Quantidade != null)
                categoriaExiste.Quantidade = dados.Quantidade;

            if (dados.Preco != null)
                categoriaExiste.Preco = dados.Preco;

            if (dados.Categoria != null)
                categoriaExiste.Categoria = dados.Categoria;

            var retorno = await _genericRepository.SaveChangesAsync();

            if (retorno is 0)
            {
                return Result.Failure("Erro ao atualizar produto!");

            }

            return Result.Success("Produto atualizado com sucesso!");
        }

        public async Task<Result> DeletarProduto(string Codigo)
        {
            var produto = await _genericRepository.GetAsync(p => p.Codigo == Codigo);

            if (produto is null)
            {
                return Result.Failure("Produto não encontrado!");
            }

            var retorno = await _genericRepository.DeleteAsync(produto);

            if (retorno is false)
            {
                return Result.Failure("Erro ao Deletar produto!");

            }

            return Result.Failure("Produto Deletado com sucesso!");
        }
    }
}
