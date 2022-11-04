using BookPublisher.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BookPublisher.Web.DTOs
{
    public class AuthorViewDTO : AbstractViewModel
    {
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Display(Name = "Sobrenome:")]
        public string LastName { get; set; }

        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Display(Name = "Data de Nascimento:")]
        public DateTime Birthdate { get; set; }

        [Display(Name = "Autores:")]
        public List<BookAuthorViewModel> BookAuthor { get; set; }
    }
}
