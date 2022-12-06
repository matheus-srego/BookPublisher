using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
    }
}
