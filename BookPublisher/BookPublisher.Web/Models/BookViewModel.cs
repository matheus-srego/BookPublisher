namespace BookPublisher.Web.Models
{
    public class BookViewModel : AbstractViewModel
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int ReleaseYear { get; set; }
    }
}
