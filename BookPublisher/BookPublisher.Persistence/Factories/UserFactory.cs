using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Interfaces.Factories;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Factories
{
    public sealed class UserFactory : IUserFactory
    {
        public User Create(NewUserDTO newUser)
        {
            return new User(newUser.Name, newUser.Email, newUser.Password);
        }
    }
}