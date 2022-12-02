using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Factories
{
    public interface IUserFactory
    {
        User Create(NewUserDTO newUser);
    }
}