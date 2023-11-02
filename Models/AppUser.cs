using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CarStocksApi.Models
{
    public class AppUser : IdentityUser
    {
        [MaxLength(40)]
        public string? Name { get; set; }
    }
}
