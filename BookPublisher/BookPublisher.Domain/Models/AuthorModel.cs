using BookPublisher.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookPublisher.Domain.Models
{
    public class AuthorModel : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }

        public static AuthorModel Create(NewAuthorDTO author)
        {
            return new AuthorModel
            {
                Name = author.Name,
                LastName = author.LastName,
                Email = author.Email,
                Birthdate = author.Birthdate

            };
        }
    }
}
