using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentalsAB.Models
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string Name { get; set; } = "";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = "";

    }
}
