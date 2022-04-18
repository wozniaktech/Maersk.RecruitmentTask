
namespace Maersk.RecruitmentTask.Helper
{
    public interface ICurrencyHelper
    {
        decimal GetCurrencyRate(string from, string to, decimal amount);
    }
}