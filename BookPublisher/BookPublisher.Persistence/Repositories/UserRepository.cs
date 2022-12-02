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
    public sealed class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(BookPublisherContext context) : base(context)
        {
            // ---
        }
    }
}
