using moyo_ismailstarke_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace moyo_ismailstarke_backend.ViewModels
{
    public class ProductViewModel
    {
        public decimal price { get; set; }
        public decimal productQuantity { get; set; }
    }
}
