namespace BookPublisher.Web.Models
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }
        public virtual BookViewModel Book { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorViewModel Author { get; set; }
    }
}
