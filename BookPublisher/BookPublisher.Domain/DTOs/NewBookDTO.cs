using BookPublisher.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.DTOs
{
    public class NewBookDTO
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int ReleaseYear { get; set; }
        public List<int> Authors { get; set; }
    }
}
