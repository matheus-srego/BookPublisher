using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        public User GetByEmail(string email);
    }
}
