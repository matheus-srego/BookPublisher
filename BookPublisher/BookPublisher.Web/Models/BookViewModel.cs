using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace BookPublisher.Web.Models
{
    public class BookViewModel : AbstractViewModel
    {
        [Required(ErrorMessage = "O campo 'Título' é obrigatório!")]
        [StringLength(100)]
        [Display(Name = "Título:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo 'ISBN' é obirgatório!")]
        [StringLength(13)]
        [Display(Name = "ISBN:")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "O campo 'Ano de Lançamento' é obrigatório!")]
        [Display(Name = "Ano de Lançamento:")]
        public int ReleaseYear { get; set; }
        
        [Required(ErrorMessage = "Deve-se selecionar ao menos um autor para o livro.")]
        [Display(Name = "Autores:")]
        public List<int> AuthorsId { get; set; }

        public BookViewModel()
        {
            AuthorsId = new List<int>();
        }
    }
}
