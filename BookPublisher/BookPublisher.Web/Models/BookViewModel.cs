using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace BookPublisher.Web.Models
{
    public class BookViewModel : AbstractViewModel
    {
        [Required(ErrorMessage = "O campo 'Título' é obrigaqtório!")]
        [StringLength(100)]
        [Display(Name = "Título:")]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo 'ISBN' é obirgatório!")]
        [StringLength(13)]
        [Display(Name = "ISBN:")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "O campo 'Ano de Lançamento' é obrigatório!")]
        [IntegerValidator]
        [Display(Name = "Ano de Lançamento:")]
        public int ReleaseYear { get; set; }
    }
}
