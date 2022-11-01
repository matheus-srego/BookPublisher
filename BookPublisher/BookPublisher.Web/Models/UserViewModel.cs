using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Web.Models
{
    public class UserViewModel : AbstractViewModel
    {
        [Required]
        [Display(Name = "Nome:")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Password { get; set; }
    }
}
