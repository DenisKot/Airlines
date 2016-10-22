namespace _01.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Airport : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        public virtual Country Country { get; set; }
    }
}