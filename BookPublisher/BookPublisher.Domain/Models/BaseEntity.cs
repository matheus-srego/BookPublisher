using System.ComponentModel.DataAnnotations;

namespace BookPublisher.Domain.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public virtual Guid Id { get; set; }
    }
}
