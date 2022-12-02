using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Services
{
    public interface IUserService : IBaseService<User>
    {
        User GetByEmail(string email);
    }
}
