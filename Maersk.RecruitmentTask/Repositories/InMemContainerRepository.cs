using Maersk.RecruitmentTask.Helpers;
using Maersk.RecruitmentTask.Model;

namespace Maersk.RecruitmentTask.Repositories
{
    public class InMemBookingPriceRepository : IInMemBookingPriceRepository
    {
        public IEnumerable<BookingPrice> GetAllPrices()
        {
            if(prices==null)
            {
                throw new Exception("Can't fetch the repository.");
            }
            return prices;
        }

        public IEnumerable<BookingPrice> GetLastPricesForGivenVoyage(string voyageCode, int quantity)
        {
            return prices.Where(x=>x.Code == voyageCode).OrderByDescending(x=>x.Timestamp).Take(quantity);
        }

        public void RegistrerNewBookingPrice(BookingPrice price)
        {
            if (price == null)
            {
                throw new Exception("BookingPrice can't be null.");
            }
            prices.Add(price);
        }

        public void UpdatePrice(BookingPrice price)
        {
            if(price == null)
            {
                throw new Exception("BookingPrice can't be null.");
            }
            var index = prices.FindIndex(existingPrice => existingPrice.Code == price.Code && existingPrice.Timestamp == price.Timestamp);
            prices[index] = price;
        }

        public BookingPrice GetPrice(string voyageCode, DateTimeOffset timestamp)
        {
            return prices.SingleOrDefault(x => x.Code == voyageCode && x.Timestamp == timestamp);
        }
             
        private readonly List<BookingPrice> prices = new()
        {
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "451S", Price = 109.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "450S", Price = 108.5M, Currency = Currency.Usd, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "449S", Price = 107.5M, Currency = Currency.Dkk, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "448S", Price = 106.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "447S", Price = 105.5M, Currency = Currency.Usd, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "446S", Price = 104.5M, Currency = Currency.Dkk, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "445S", Price = 103.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "444S", Price = 102.5M, Currency = Currency.Usd, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "443S", Price = 101.5M, Currency = Currency.Dkk, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "442S", Price = 100.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "441S", Price = 99.5M, Currency = Currency.Usd, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "440S", Price = 98.5M, Currency = Currency.Dkk, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "439S", Price = 97.5M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "aaa", Price = 100M, Currency = Currency.Usd, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "aaa", Price = 200M, Currency = Currency.Gbp, Timestamp = DateTimeOffset.Now },
            new BookingPrice { Code = "aaa", Price = 300M, Currency = Currency.Dkk, Timestamp = DateTimeOffset.Now },
        };
    }
}