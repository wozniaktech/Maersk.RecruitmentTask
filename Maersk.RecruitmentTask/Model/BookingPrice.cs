using Maersk.RecruitmentTask.Helpers;

namespace Maersk.RecruitmentTask.Model
{
    public class BookingPrice
    {
        public string? Code { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }
        public DateTimeOffset Timestamp { get; set; }
    }
}
