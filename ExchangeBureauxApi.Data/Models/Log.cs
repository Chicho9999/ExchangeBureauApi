using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeBureauxApi.Data.Models
{
    public class Log : EntityBase
    {
        [Key]
        public int LogId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Aplication { get; set; }

        [Required]
        public int Level { get; set; }

        [Required]
        [MaxLength(250)]
        public string Message { get; set; }

        [Required]
        [MaxLength(50)]
        public string Exception { get; set; }
    }
}
