using Maersk.RecruitmentTask.Helpers;
using System.ComponentModel.DataAnnotations;

namespace Maersk.RecruitmentTask.Dtos
{
    public class CreateBookingPriceDto
    {
        [Required]
        public string? Code { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public Currency Currency { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
