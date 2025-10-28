using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;

namespace ControleDeEstoque.Domain.Interfaces
{
    public interface IEstoqueService
    {
        Task<List<Produto>> ListarProdutos();
        Task<string> AddProduto(ProdutoDto dados);
        Task<string> AtualizarProduto(ProdutoDto dados);
        Task<string> DeletarProduto(int id);
    }
}
