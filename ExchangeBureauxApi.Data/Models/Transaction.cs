using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeBureauxApi.Data.Models
{
    public class Transaction : EntityBase
    {
        [Key]
        public int TransactionId { get; set; }

        [MaxLength(250)]
        [Required]
        public string Description { get; set; }

        [Required]
        public double AmountToConvert { get; set; }

        [Required]
        public double AmountConverted { get; set; }

        [Required]
        [ForeignKey(nameof(CurrencyFrom))]
        public int CurrencyFromId { get; set; }

        [Required]
        [ForeignKey(nameof(CurrencyTo))]
        public int CurrencyToId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        public Currency CurrencyFrom { get; set; }

        public Currency CurrencyTo { get; set; }

        public User User { get; set; }
    }
}
