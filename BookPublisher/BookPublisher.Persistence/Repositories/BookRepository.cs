using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Context;

namespace BookPublisher.Persistence.Repositories
{
    public sealed class BookRepository : BaseRepository<BookModel>, IBookRepository
    {
        public BookRepository(BookPublisherContext context) : base(context)
        {
            // ---
        }
    }
}
