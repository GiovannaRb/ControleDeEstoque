using ControleDeEstoque.API.Data;
using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControleDeEstoque.API.Repository
{
    public class EstoqueRepository : IEstoqueRepository
    {
        private readonly AppDbContext _context;
        public EstoqueRepository(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<List<Produto>> ListarProdutos()
        {
            try
            {
                return await _context.Produtos.ToListAsync();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        public async Task<string> AddProduto(Produto dados)
        {
            try
            {
                await _context.Produtos.AddAsync(dados);
                _context.SaveChangesAsync();

                return "Produto adicionado com sucesso";
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<string> DeletarProduto(int id)
        {
            try
            {
                var produto = await _context.Produtos.Where(p => p.Id == id).FirstOrDefaultAsync();

                if (produto == null)
                    return "Produto não encontrado";

                _context.Produtos.Remove(produto);
                _context.SaveChangesAsync();

                return "Produto deletado com sucesso";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpDelete]
        public async Task<string> AtualizarProduto(Produto dados)
        {
            try
            {
                _context.Produtos.Update(dados);
                _context.SaveChangesAsync();

                return "Produto atualizado com sucesso";
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
