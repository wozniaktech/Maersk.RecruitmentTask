using Maersk.RecruitmentTask.Helpers;
using Maersk.RecruitmentTask.Model;

namespace Maersk.RecruitmentTask.Repositories
{
    public interface IInMemBookingPriceRepository
    {
        IEnumerable<BookingPrice> GetAllPrices();
        IEnumerable<BookingPrice> GetLastPricesForGivenVoyage(string voyageCode, int quantity);
        BookingPrice GetPrice(string voyageCode, DateTimeOffset timestamp);
        void RegistrerNewBookingPrice(BookingPrice price);
        void UpdatePrice(BookingPrice price);
    }
}
