using BookPublisher.Domain.Constants;
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
                throw new ArgumentException(EXCEPTIONS.MESSAGE_USER_TYPE_NOT_EXIST);
            
            return new User(newUser.Name, newUser.Lastname, newUser.Email, newUser.Password, userType);
        }

        public UserResponseDTO ConvertModelToDTO(User? user)
        {
            return new UserResponseDTO(user.Id, user.Name, user.Lastname, user.Email, user.UserType);
        }
    }
}