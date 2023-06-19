using System.ComponentModel.DataAnnotations;

namespace moyo_ismailstarke_backend.ViewModels
{
    public class OrderStatusViewModel
    {
        [Required]
        public string status { get; set; }
    }
}
