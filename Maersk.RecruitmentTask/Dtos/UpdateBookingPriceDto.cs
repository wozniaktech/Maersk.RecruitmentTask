using Maersk.RecruitmentTask.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Maersk.RecruitmentTask.Dtos
{
    public class UpdateBookingPriceDto
    {
        [Required]
        public DateTimeOffset Timestamp { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Currency Currency { get; set; }
    }
}
