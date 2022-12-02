using BookPublisher.Domain.Constants;
using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using FluentValidation;
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

        public async Task<T> InsertAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
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

        public void Validate(T entity, AbstractValidator<T> validator)
        {
            if(entity == null)
                throw new Exception(Exceptions.MESSAGE_INCOMPLETE_INFORMATION);

            validator.ValidateAndThrow(entity);
        }
    }
}
