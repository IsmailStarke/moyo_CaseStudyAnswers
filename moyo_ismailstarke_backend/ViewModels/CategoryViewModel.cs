using System.ComponentModel.DataAnnotations;

namespace moyo_ismailstarke_backend.ViewModels
{
    public class CategoryViewModel
    {
        [Required]
        public string description { get; set; }
    }
}
