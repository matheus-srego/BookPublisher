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
    public sealed class BookRepository : BaseRepository<BookModel>, IBookRepository
    {
        public BookRepository(BookPublisherContext context) : base(context)
        {
            // ---
        }
    }
}
