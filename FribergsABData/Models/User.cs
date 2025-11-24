using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using FribergsABData;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.EntityFrameworkCore;

namespace FribergsABData.Models
{
    public class User 
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; } = "";
        [Required]
        public string? FirstName { get; set; } = "";
        [Required]
        public string? LastName { get; set; } = "";
        public string? Name => $"{FirstName} {LastName}";
        [Required]
        public string Password { get; set; } = "";
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; } = "";

     

    }
}