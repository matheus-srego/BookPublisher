using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Web.Models
{
    public class AuthorViewModel : AbstractViewModel
    {
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório!")]
        [StringLength(50)]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "O campo 'Sobrenome' é obrigatório!")]
        [StringLength (50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "O campo 'E-mail' é obrigatório!")]
        [StringLength(50)]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo 'Data de Nascimento' é obrigatório!")]
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }
    }
}
