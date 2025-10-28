using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleDeEstoque.Domain.Interfaces
{
    public interface IEstoqueRepository
    {
        Task<List<Produto>> ListarProdutos();
        Task<string> AddProduto(Produto dados);
        Task<string> AtualizarProduto(Produto dados);
        Task<string> DeletarProduto(int id);
    }
}
