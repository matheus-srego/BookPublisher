using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IAuthorService : IBaseService<AuthorModel>
    {
        Task<IEnumerable<AuthorModel>> ListAuthorsWithBookAsync();
        Task<AuthorModel> GetAuthorWithBooksAsync(int id);
    }
}
