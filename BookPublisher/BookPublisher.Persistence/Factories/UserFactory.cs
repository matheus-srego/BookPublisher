using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Enums;
using BookPublisher.Domain.Interfaces.Factories;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Factories
{
    public sealed class UserFactory : IUserFactory
    {
        public User Create(NewUserDTO newUser)
        {
            var typeExist = System.Enum.TryParse<UserType>(newUser.UserType, out UserType userType);
            if(!typeExist)
                throw new ArgumentException($"O tipo '{newUser.UserType}' não existe");
            
            return new User(newUser.Name, newUser.Lastname, newUser.Email, newUser.Password, userType);
        }
    }
}