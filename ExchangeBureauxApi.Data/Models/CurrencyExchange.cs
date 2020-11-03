using System.ComponentModel.DataAnnotations;

namespace ExchangeBureauxApi.Data.Models
{
    public class CurrencyExchange : EntityBase
    {
        [Key]
        public int CurrencyExchangeId { get; set; }

        [Required]
        public double InverseConversionValue { get; set; }

        [Required]
        public double ConversionValue { get; set; }

        [Required]
        public int CurrencyFromId { get; set; }

        [Required]
        public int CurrencyToId { get; set; }
        
        public Currency CurrencyFrom { get; set; }

        public Currency CurrencyTo { get; set; }
    }
}
