using System.ComponentModel.DataAnnotations;

namespace moyo_ismailstarke_backend.ViewModels
{
    public class OrderViewModel
    {
        public DateTime OrderDate { get; set; }
        public string emailaddress { get; set; }
        public int OrderStatusId { get; set; }
        public decimal TotalPrice { get; set; }
        public int[] productId { get; set; }
        public int[] quantity { get; set; }
    }
}