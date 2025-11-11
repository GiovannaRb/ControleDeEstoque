using ControleDeEstoque.API.Domain.Models;
using ControleDeEstoque.Domain.Dtos;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ControleDeEstoque.Domain.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<bool> DeleteAsync(T entity);
    }
}
