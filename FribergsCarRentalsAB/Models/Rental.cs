using System.ComponentModel.DataAnnotations;

namespace FribergsCarRentalsAB.Models
{
    public class Rental
    {
        public int Id { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? CarId { get; set; }
        public  User? User { get; set; }
        public  Car? Car { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }
    }
}
