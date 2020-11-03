using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ExchangeBureauxApi.Data.Models
{
    public class User : EntityBase
    {
        [Key]
        public int UserId { get; set; }

        [MaxLength(250)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(250)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(250)]
        [Required]
        public string Username { get; set; }

        [MaxLength(250)]
        [Required]
        public string Email { get; set; }

        [MaxLength(250)]
        [Required]
        public string Password { get; set; }

        [MaxLength(250)]
        [Required]
        public string Address { get; set; }

        public virtual ICollection<LimitPucharse> LimitPucharses { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
