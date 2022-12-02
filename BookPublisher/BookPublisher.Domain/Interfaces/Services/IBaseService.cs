using BookPublisher.Domain.Models;
using FluentValidation;
using System.Linq.Expressions;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<T> GetAsync(int id);
        T GetOneByCriteria(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> ListAsync();
        Task<T> InsertAsync<TValidator>(T entity) where TValidator : AbstractValidator<T>;
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int ind);

        void Validate(T entity, AbstractValidator<T> validator);
    }
}
