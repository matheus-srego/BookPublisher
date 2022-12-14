using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        public UserModel GetByEmail(string email);
    }
}
