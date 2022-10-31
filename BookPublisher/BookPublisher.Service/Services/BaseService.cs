using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using System.Linq.Expressions;

namespace BookPublisher.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<T> GetAsync(int id)
        {
            return await _baseRepository.GetAsync(id);
        }

        public T GetOneByCriteria(Expression<Func<T, bool>> expression)
        {
            return _baseRepository.GetOneByCriteria(expression);
        }

        public async Task<IEnumerable<T>> ListAsync()
        {
            return await _baseRepository.ListAsync();
        }

        public async Task<T> InsertAsync(T entity)
        {
            return await _baseRepository.InsertAsync(entity);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            return await _baseRepository.UpdateAsync(entity);
        }

        public async Task<T> DeleteAsync(int id)
        {
            return await _baseRepository.DeleteAsync(id);
        }
    }
}
