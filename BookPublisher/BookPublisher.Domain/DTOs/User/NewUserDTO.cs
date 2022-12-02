namespace BookPublisher.Domain.DTOs.User
{
    public class NewUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public NewUserDTO(string name, string email, string password)
        {
            Name = name;
            Email = email;
            Password = password;            
        }
    }
}