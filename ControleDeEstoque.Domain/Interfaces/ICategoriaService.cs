using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using ControleDeEstoque.Domain.Shared;

namespace ControleDeEstoque.Domain.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> ListarCategorias();
        Task<Result> AddCategoria(CategoriaDto dados);
        Task<Result> AtualizarCategoria(CategoriaDto dados);
        Task<Result> DeletarCategoria(string Nome);
    }
}
