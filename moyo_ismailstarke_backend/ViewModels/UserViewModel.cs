using System.ComponentModel.DataAnnotations;

namespace moyo_ismailstarke_backend.ViewModels
{
    public class UserViewModel
    {
        [StringLength(100)]
        public string emailaddress { get; set; }
        public string password { get; set; }
    }
}
