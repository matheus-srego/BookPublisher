using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Web.Models
{
    public class AbstractViewModel
    {
        [Display(Name = "Identificador:")]
        public virtual int Id { get; set; }
    }
}
