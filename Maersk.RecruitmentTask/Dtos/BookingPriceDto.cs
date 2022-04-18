using Maersk.RecruitmentTask.Helpers;
using Maersk.RecruitmentTask.Model;

namespace Maersk.RecruitmentTask.Dtos
{
    public class BookingPriceDto
    {
        public string? Code { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
