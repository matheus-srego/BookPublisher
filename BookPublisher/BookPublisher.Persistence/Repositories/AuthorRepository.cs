using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Persistence.Repositories
{
    internal sealed class AuthorRepository : BaseRepository<AuthorModel>, IAuthorRepository
    {
        public AuthorRepository(BookPublisherContext context) : base(context)
        {
            // ---
        }
    }
}
