using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Interfaces;
using ControleDeEstoque.Domain.Models.Dtos;
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

        public async Task<IEnumerable<CategoriaDto>> ListarCategorias()
        {  
            var listaCategoria = await _genericRepository.GetAllAsync();

            var retorno = listaCategoria.Select( c => new CategoriaDto
            {
                Nome = c.Nome,
                Descricao = c.Descricao
            });

            return retorno;
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

            var categoriaExiste = await _genericRepository.GetAsync(p => p.Nome == dados.Nome);

            if (categoriaExiste == null)
                return Result.Failure("Categoria não encontrada!");

            if (dados.Nome != null)
                categoriaExiste.Nome = dados.Nome;
            if (dados.Descricao != null)
                categoriaExiste.Descricao = dados.Descricao;

            var retorno = await _genericRepository.SaveChangesAsync();

            if (retorno is 0)
            {
                return Result.Failure("Erro ao atualizar categoria!");

            }

            return Result.Success("Categoria atualizada com sucesso!");
        }

        public async Task<Result> DeletarCategoria(string Nome)
        {
            var categoria = await _genericRepository.GetAsync(p => p.Nome == Nome);
            if (categoria is null)
            {
                return Result.Failure("Erro ao encontrar categoria!");

            }


            var retorno = await _genericRepository.DeleteAsync(categoria);

            if (retorno is false)
            {
                return Result.Failure("Erro ao deletar categoria!");

            }

            return Result.Success("Categoria deletada com sucesso!");
        }
    }
}
