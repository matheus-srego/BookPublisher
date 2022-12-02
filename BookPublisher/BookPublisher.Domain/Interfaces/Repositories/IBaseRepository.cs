using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(int? id);
        Task<IEnumerable<T?>> ListAsync();
        Task<T?> InsertAsync(T? entity);
        Task<T?> UpdateAsync(T? entity);
        Task<T?> DeleteAsync(T? entity);
    }
}
