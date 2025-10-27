using ControleDeEstoque.API.Domain.Models;

namespace ControleDeEstoque.API.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<List<Produto>> ListarProdutos();
        Task<string> AddProduto(Produto dados);
        Task<string> AtualizarProduto(Produto dados);
        Task<string> DeletarProduto(int id);
    }
}
