using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;

namespace BookPublisher.Service.Services
{
    public sealed class AuthorService : BaseService<AuthorModel>, IAuthorService
    {
        public AuthorService(IAuthorRepository authorRepository) : base(authorRepository)
        {
            // ---
        }
    }
}
