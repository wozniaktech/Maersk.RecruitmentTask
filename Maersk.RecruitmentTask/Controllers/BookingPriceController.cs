using Maersk.RecruitmentTask.Dtos;
using Maersk.RecruitmentTask.Helper;
using Maersk.RecruitmentTask.Helpers;
using Maersk.RecruitmentTask.Model;
using Maersk.RecruitmentTask.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Maersk.RecruitmentTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingPriceController : Controller
    {
        private readonly IInMemBookingPriceRepository repository;
        private readonly ICurrencyHelper currencyHelper;
        private readonly ILogger logger;
        public BookingPriceController(IInMemBookingPriceRepository repository, ICurrencyHelper currencyHelper, ILogger logger)
        {
            this.repository = repository;
            this.currencyHelper = currencyHelper;
            this.logger = logger;
        }
        
        [HttpGet]
        public IEnumerable<BookingPriceDto> GetLastPrices()
        {
            return repository.GetAllPrices().Select(x=>x.AsDto());
        }

        [HttpGet("{code}")]
        public IEnumerable<BookingPrice> GetLastTenPricesForGivenVoyage(string code, int quantity = 10) 
        {
            if(string.IsNullOrEmpty(code))
            {
                logger.LogInformation("Code can't be null or empty.");
                throw new ArgumentNullException(nameof(code));
            }
            if(quantity<=0)
            {
                logger.LogInformation("Quantity must be bigger then zero.");
                throw new Exception("Quantity must be bigger then zero.");
            }
            return repository.GetLastPricesForGivenVoyage(code, quantity);
        }

        [HttpPost]
        public ActionResult<BookingPriceDto> RegisterNewBookingPrice(CreateBookingPriceDto price)
        {
            if(price==null)
            {
                logger.LogInformation("Parameter can't be null.");
                throw new Exception("Parameter can't be null.");
            }

            var newBookingPrice = new BookingPrice
            {
                Code = price.Code,
                Price = price.Price,
                Currency = price.Currency,
                Timestamp = DateTimeOffset.Now
            };
            repository.RegistrerNewBookingPrice(newBookingPrice);

            return CreatedAtAction(nameof(GetLastPrices), new { Code = newBookingPrice.Code }, newBookingPrice.AsDto());
        }

        [HttpPut("{code}")]
        public ActionResult UpdatePrice(string code, UpdateBookingPriceDto priceDto)
        {
            if (string.IsNullOrEmpty(code))
            {
                logger.LogInformation("Code can't be null or empty.");
                throw new ArgumentNullException(nameof(code));
            }

            if(priceDto==null)
            {
                logger.LogInformation("Parameter can't be null.");
                throw new Exception("Parameter can't be null.");
            }

            var existingPrice = repository.GetPrice(code, priceDto.Timestamp);

            if (existingPrice is null)
            {
                return NotFound();
            }

            if (existingPrice.Currency != priceDto.Currency)
            {
                existingPrice.Currency = priceDto.Currency;
            }

            existingPrice.Price = priceDto.Price;
            existingPrice.Timestamp = DateTimeOffset.Now;

            repository.UpdatePrice(existingPrice);
            return NoContent();
        }

        [HttpGet("{code}/{currency}")]
        public decimal GetAveragePrice(string code, Currency currency)
        {
            if (string.IsNullOrEmpty(code))
            {
                logger.LogInformation("Code can't be null or empty.");
                throw new ArgumentNullException(nameof(code));
            }

            decimal calculatedPrice = 0;
            decimal sum = 0;
            int count = 0;
            
            foreach (var price in repository.GetAllPrices())
            {
                if (price.Code == code)
                {
                    if (price.Currency == currency)
                    { 
                        sum = sum + price.Price;
                        count++;
                    }
                    if (price.Currency != currency)
                    {
                        calculatedPrice = currencyHelper.GetCurrencyRate(price.Currency.ToString(), currency.ToString(), price.Price);

                        sum = sum + calculatedPrice;
                        count++;
                    }
                }
            }
            if (sum == 0 || count == 0)
            {
                logger.LogInformation("Can't divide by zero.");
                throw new DivideByZeroException("Can't divide by zero.");
            }
            return sum/ count;
        }
    }
}
