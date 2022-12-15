using BookPublisher.Domain.Enums;
using BookPublisher.Domain.Models;

namespace BookPublisher.Domain.DTOs.User
{
    public class UserResponseDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public UserResponseDTO(Guid id, string name, string lastname, string email, UserType userType)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
            Email = email;
            UserType = userType;
        }
    }
}