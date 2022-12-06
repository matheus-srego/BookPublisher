using BookPublisher.Domain.Enums;

namespace BookPublisher.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserType UserType { get; set; }

        public User(string name, string lastname, string email, string password, UserType userType)
        {
            Name = name;
            Lastname = lastname;
            Email = email;
            Password = password;
            UserType = userType;
        }
    }
}
