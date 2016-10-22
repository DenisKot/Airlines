namespace _01.Domain
{
    using System.ComponentModel.DataAnnotations;

    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}