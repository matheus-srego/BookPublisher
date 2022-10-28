using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Repositories
{
    public interface IBookRepository : IBaseRepository<BookModel>
    {
        // Task<BookModel> InsertBookWithAuthorAsync(BookModel model);
    }
}
