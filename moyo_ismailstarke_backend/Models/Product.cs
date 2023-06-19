using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moyo_ismailstarke_backend.Models
{
    public class Product
    {
        [Required]
        [Key]
        public int productId { get; set; }

        [Required]
        [StringLength(50)]
        public String description { get; set; }

        [Required]
        public decimal price { get; set; }

        [Required]
        public decimal productQuantity { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }
    }
}
