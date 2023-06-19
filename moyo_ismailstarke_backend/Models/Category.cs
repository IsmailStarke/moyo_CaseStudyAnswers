using System.ComponentModel.DataAnnotations;

namespace moyo_ismailstarke_backend.Models
{
    public class Category
    {
        [Required]
        [Key]
        public int categoryId { get; set; }

        [Required]
        public String description { get; set; }

        //public ICollection<Product> products { get; set; }
    }
}
