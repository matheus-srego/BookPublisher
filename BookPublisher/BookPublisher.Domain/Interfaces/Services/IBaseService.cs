using BookPublisher.Domain.Models;
using FluentValidation;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T?> GetAsync(Guid id);
        Task<IEnumerable<T?>> ListAsync();
        Task<T?> InsertAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task<T?> UpdateAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task<T?> DeleteAsync(Guid ind);

        void Validate(T entity, AbstractValidator<T> validator);
    }
}
