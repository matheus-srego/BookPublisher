

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Web.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "É necessário inserir um e-mail.")]
        [EmailAddress]
        [Display(Name = "E-mail:")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário inserir uma senha.")]
        [DataType(DataType.Password)]
        [Display(Name = "Senha:")]
        public string Password { get; set; }
    }
}
