using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using ControleDeEstoque.Domain.Interfaces;
using ControleDeEstoque.Domain.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeEstoque.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly IGenericRepository<Categoria> _genericRepository;
        public CategoriaService(IGenericRepository<Categoria> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Categoria>> ListarCategorias()
        {  
           return await _genericRepository.GetAllAsync();
        }

        public async Task<Result> AddCategoria(CategoriaDto dados)
        {
            var categoria = new Categoria
            {
                Nome = dados.Nome,
                Descricao = dados.Descricao,
            };

            var categoriaExiste = await _genericRepository.GetAsync(p => p.Nome == dados.Nome);

            if (categoriaExiste != null)
                return Result.Failure("Esta categoria já existe!");

            var addProduto = await _genericRepository.AddAsync(categoria);

            if (addProduto is false)
            {
                return Result.Failure("Erro ao adicionar categoria!");
            }

            return Result.Success("Categoria cadastrada com sucesso!");
        }
        public async Task<Result> AtualizarCategoria(CategoriaDto dados)
        {
            var categoria = new Categoria
            {
                Nome = dados.Nome,
                Descricao = dados.Descricao,
            };

            var retorno = await _genericRepository.UpdateAsync(categoria);

            if (retorno is false)
            {
                return Result.Failure("Erro ao atualizar categoria!");

            }

            return Result.Failure("Categoria atualizada com sucesso!");
        }

        public async Task<Result> DeletarCategoria(string Nome)
        {
            var categoria = await _genericRepository.GetAsync(p => p.Nome == Nome);

            var retorno = await _genericRepository.DeleteAsync(categoria);

            if (retorno is false)
            {
                return Result.Failure("Erro ao deletar categoria!");

            }

            return Result.Failure("Categoria deletada com sucesso!");
        }
    }
}
