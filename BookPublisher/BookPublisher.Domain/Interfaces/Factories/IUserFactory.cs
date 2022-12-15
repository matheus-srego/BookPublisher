using BookPublisher.Domain.DTOs.User;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.Interfaces.Factories
{
    public interface IUserFactory
    {
        User Create(UserRequestDTO newUser);
        User Update(Guid id, UserRequestDTO updateUser);
        UserResponseDTO ConvertModelToDTO(User? user);
    }
}