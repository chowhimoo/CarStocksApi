using System.ComponentModel.DataAnnotations;

namespace CarStocksApi.Models
{
    public class Register
    {
        [Required(ErrorMessage = "Please Enter User Name")]
        public string? Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please Enter Email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        public string? Password { get; set; }

    }
}
