using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeBureauxApi.Data.Models
{
    public class LimitPucharse : EntityBase
    {
        [Key]
        public int LimitPucharseId { get; set; }
        
        [Required]
        public double MaxAmountToBuy { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Currency))]
        public int CurrencyId { get; set; }

        public User User { get; set; }

        public Currency Currency { get; set; }
    }
}
