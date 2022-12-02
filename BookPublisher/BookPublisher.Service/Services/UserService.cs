using BookPublisher.Domain.Interfaces.Repositories;
using BookPublisher.Domain.Interfaces.Services;
using BookPublisher.Domain.Models;

namespace BookPublisher.Service.Services
{
    public sealed class UserService : BaseService<User>, IUserService
    {
        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            // ---
        }
    }
}
