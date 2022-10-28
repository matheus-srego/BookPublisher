using BookPublisher.Domain.Models;
using BookPublisher.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Persistence.Repositories
{
    public class BookAuthorRepository : BaseRepository<BookAuthorModel>
    {
        public BookAuthorRepository(BookPublisherContext context) : base(context)
        {
            // ---
        }
    }
}
