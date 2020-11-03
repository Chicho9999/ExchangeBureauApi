using System;
using System.ComponentModel.DataAnnotations;

namespace ExchangeBureauxApi.Data.Models
{
    public abstract class EntityBase
    {
        [Required]
        public int CreatedBy { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
