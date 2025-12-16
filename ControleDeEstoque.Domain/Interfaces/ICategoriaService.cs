using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Models.Dtos;
using ControleDeEstoque.Domain.Shared;

namespace ControleDeEstoque.Domain.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> ListarCategorias();
        Task<Result> AddCategoria(CategoriaDto dados);
        Task<Result> AtualizarCategoria(CategoriaDto dados);
        Task<Result> DeletarCategoria(string Nome);
    }
}
