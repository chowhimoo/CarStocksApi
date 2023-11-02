using System.ComponentModel.DataAnnotations;

namespace CarStocksApi.Models
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        public string? username { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
        public string? password { get; set; }

    }
}