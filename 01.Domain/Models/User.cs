namespace _01.Domain.Models
{
    using System.ComponentModel.DataAnnotations;

    public class User : BaseEntity
    {
        [MaxLength(256)]
        public string Name { get; set; }

        [MaxLength(256)]
        public string Login { get; set; }

        [MaxLength(256)]
        public string Password { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }

        [MaxLength(256)]
        public string CardNumber { get; set; }
    }
}