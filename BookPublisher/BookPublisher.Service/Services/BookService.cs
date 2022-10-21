using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;

namespace BookPublisher.Service.Services
{
    public sealed class BookService : BaseService<BookModel>, IBookService
    {
        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
            // ---
        }
    }
}
