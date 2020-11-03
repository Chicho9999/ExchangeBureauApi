using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeBureauxApi.Data.Models
{
    public class Currency : EntityBase
    {
        [Key]
        public int CurrencyId { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(3)]
        [Required]
        public string Identifier { get; set; }

        public virtual ICollection<CurrencyExchange> FromCurrencyExchanges { get; set; }

        public virtual ICollection<CurrencyExchange> ToCurrencyExchanges { get; set; }

        public virtual ICollection<Transaction> ToTransactions { get; set; }

        public virtual ICollection<Transaction> FromTransactions { get; set; }
    }
}
