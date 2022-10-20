using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Context;

namespace BookPublisher.Persistence.Repositories
{
    public sealed class AuthorRepository : BaseRepository<AuthorModel>, IAuthorRepository
    {
        public AuthorRepository(BookPublisherContext context) : base(context)
        {
            // ---
        }
    }
}
