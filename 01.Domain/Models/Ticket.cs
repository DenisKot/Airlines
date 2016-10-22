namespace _01.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Ticket : BaseEntity
    {
        [Required]
        public DateTime CreationDate { get; set; }

        [MaxLength(512)]
        public string Transaction { get; set; }

        [MaxLength(512)]
        public string Details { get; set; }

        [MaxLength(16)]
        public string Sit { get; set; }

        [MaxLength(512)]
        public string Email { get; set; }

        public bool IsSetToEmail { get; set; }

        public virtual User User { get; set; }
    }
}