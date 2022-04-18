using Maersk.RecruitmentTask.Model;

namespace Maersk.RecruitmentTask.Dtos
{
    public static class Extensions
    {
        public static BookingPriceDto AsDto (this BookingPrice price)
        {
            return new BookingPriceDto
            {
                Price = price.Price,
                Code = price.Code,
                Currency = price.Currency,
                Timestamp = price.Timestamp
            };
        }
    }
}
