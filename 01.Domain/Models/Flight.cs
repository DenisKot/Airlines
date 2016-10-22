namespace _01.Domain.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Flight : BaseEntity
    {
        [Required]
        [MaxLength(512)]
        public string Name { get; set; }

        [Required]
        public decimal Coast { get; set; }

        [Required]
        public DateTime? LeavingTime { get; set; }

        [Required]
        public DateTime? Arrives { get; set; }

        public virtual Airport AirportFrom { get; set; }

        public virtual Airport AirportTo { get; set; }
    }
}