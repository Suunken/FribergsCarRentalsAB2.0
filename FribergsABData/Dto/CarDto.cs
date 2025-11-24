using FribergsABData.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergsABData.Dto
{
    public class CarDto 
    {
        [Required]
        public string? Brand { get; set; }
        [Required]
        public string? Color { get; set; }
        [Required]
        public bool Rentable { get; set; } = true;
        public string? CarPicUrl1 { get; set; } = "";
        public string? CarPicUrl2 { get; set; } = "";

    }
}
