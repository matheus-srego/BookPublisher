using BookPublisher.Domain.Enums;

namespace BookPublisher.Domain.DTOs.User
{
    public class NewUserDTO
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }

        public NewUserDTO(string name, string lastname, string email, string password, string userType)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}