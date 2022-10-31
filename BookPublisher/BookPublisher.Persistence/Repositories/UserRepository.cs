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
    public sealed class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        protected readonly BookPublisherContext _context;

        public UserRepository(BookPublisherContext context) : base(context)
        {
            _context = context;
        }

        public UserModel GetByEmail(string email)
        {
            return _context.Find<UserModel>(email);
        }
    }
}
