using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCandle.Models
{
    public class Candle
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "Fragrance")]
        [Required]
        public string Fragrance { get; set; }

        [StringLength(60, MinimumLength = 3)]
        public string Color { get; set; }

        [StringLength(60, MinimumLength = 3)]
        
        public string Shape { get; set; }

        [Range(1, 100000)]
        [Required]
        public int Size { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(5)]
        [Required]
        public string Rating { get; set; }

    }
}
