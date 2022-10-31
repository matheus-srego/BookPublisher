using BookPublisher.Domain.Models;
using System.Linq.Expressions;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        T GetOneByCriteria(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> ListAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int ind);
    }
}
