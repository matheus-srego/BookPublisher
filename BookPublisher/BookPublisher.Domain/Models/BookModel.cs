using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Models
{
    public class BookModel : BaseEntity
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int ReleaseYear { get; set; }
    }
}
