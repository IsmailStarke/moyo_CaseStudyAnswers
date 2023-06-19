using System.ComponentModel.DataAnnotations;

namespace moyo_ismailstarke_backend.Models
{
    public class OrderStatus
    {
        [Key]
        public int OrderStatusId { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
