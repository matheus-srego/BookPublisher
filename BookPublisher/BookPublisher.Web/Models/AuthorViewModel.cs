namespace BookPublisher.Web.Models
{
    public class AuthorViewModel : AbstractViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
