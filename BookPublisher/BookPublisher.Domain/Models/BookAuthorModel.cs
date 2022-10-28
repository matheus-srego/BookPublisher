using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Models
{
    public class BookAuthorModel : BaseEntity
    {
        public int BookId { get; set; }
        public virtual BookModel Book { get; set; }
        public int AuthorId { get; set; }
        public virtual AuthorModel Author { get; set; }
    }
}
