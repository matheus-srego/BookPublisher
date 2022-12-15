using System.Linq.Expressions;
using BookPublisher.Domain.Models;
using FluentValidation;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<IEnumerable<T?>> ListAsync();
        Task<T?> GetAsync(Guid id);
        Task<T?> GetByCriteriaAsync(Expression<Func<T, bool>> expression);
        Task<T?> InsertAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task<T?> UpdateAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task<T?> DeleteAsync(Guid ind);

        void Validate(T entity, AbstractValidator<T> validator);
    }
}
