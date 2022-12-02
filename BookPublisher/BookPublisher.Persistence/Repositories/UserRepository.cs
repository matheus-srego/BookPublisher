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
        protected readonly BookPublisherContext _context;

        public UserRepository(BookPublisherContext context) : base(context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Find<User>(email);
        }
    }
}
