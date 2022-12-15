using BookPublisher.Domain.Constants;
using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;
using FluentValidation;

namespace BookPublisher.Service.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _baseRepository;

        public BaseService(IBaseRepository<T> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual async Task<IEnumerable<T?>> ListAsync() => await _baseRepository.ListAsync();

        public virtual async Task<T?> GetAsync(Guid id) => await _baseRepository.GetAsync(id);
        
        public virtual async Task<T?> InsertAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            return await _baseRepository.InsertAsync(entity);
        }

        public virtual async Task<T?> UpdateAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>
        {
            Validate(entity, Activator.CreateInstance<TValidator>());
            return await _baseRepository.UpdateAsync(entity);
        }

        public virtual async Task<T?> DeleteAsync(Guid id) => await _baseRepository.DeleteAsync(await _baseRepository.GetAsync(id));

        public void Validate(T entity, AbstractValidator<T> validator)
        {
            if(entity == null)
                throw new Exception(EXCEPTIONS.MESSAGE_INCOMPLETE_INFORMATION);

            validator.ValidateAndThrow(entity);
        }
    }
}
