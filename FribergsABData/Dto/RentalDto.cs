using FribergsABData.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergsABData.Dto
{
    public class RentalDto
    {
        [Required]
        public int? UserId { get; set; }
        [Required]
        public int? CarId { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime End { get; set; }


    }
}
