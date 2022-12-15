using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Interfaces.Factories;
using BookPublisher.Domain.Models;
using BookPublisher.Service.Services.Utils;

namespace BookPublisher.Domain.Factories
{
    public sealed class UserFactory : IUserFactory
    {
        public User Create(UserRequestDTO newUser)
        {
            var user = new User(newUser.Name, newUser.Lastname, newUser.Email, newUser.Password, Utils.TypeExist(newUser.UserType));
            return user;
        }

        public User Update(Guid id, UserRequestDTO updateUser)
        {
            return new User(id, updateUser.Name, updateUser.Lastname, updateUser.Email, updateUser.Password, Utils.TypeExist(updateUser.UserType));
        }

        public UserResponseDTO ConvertModelToDTO(User? user)
        {
            User userVerified = Utils.UserHasInformation(user);
            return new UserResponseDTO(userVerified.Id, userVerified.Name, userVerified.Lastname, userVerified.Email, userVerified.UserType);
        }
    }
}