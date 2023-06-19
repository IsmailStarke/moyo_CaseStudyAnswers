using moyo_ismailstarke_backend.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moyo_ismailstarke_backend.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        [ForeignKey("UserName")]
        public string UserName { get; set; }

        public User User { get; set; }

        [Required]
        [ForeignKey("OrderStatusId")]
        public int OrderStatusId { get; set; }

        public OrderStatus OrderStatus { get; set; }

        [Required]
        [ForeignKey("OrderItemId")]
        public int OrderItemId { get; set; }

        public OrderItem OrderItem { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
