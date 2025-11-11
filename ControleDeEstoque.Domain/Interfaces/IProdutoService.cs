using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using ControleDeEstoque.Domain.Shared;

namespace ControleDeEstoque.Domain.Interfaces
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> ListarProdutos();
        Task<Result> AddProduto(ProdutoDto dados);
        Task<Result> AtualizarProduto(ProdutoDto dados);
        Task<Result> DeletarProduto(string Codigo);
    }
}
