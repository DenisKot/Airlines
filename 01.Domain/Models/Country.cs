namespace _01.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Country : BaseEntity
    {
        [Required]
        [MaxLength(256)]
        public string Name { get; set; }
    }
}