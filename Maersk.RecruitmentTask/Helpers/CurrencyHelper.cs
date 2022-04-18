namespace Maersk.RecruitmentTask.Helper
{
    public class CurrencyHelper : ICurrencyHelper
    {
        private Dictionary<string, decimal> getCurrencyRates => CurrencyRates;

        public decimal GetCurrencyRate(string from, string to, decimal amount = 1)
        {
            if (from == null || to == null)
                return 0;

            if (from == to)
                return 0;

            if (amount <= 0)
                return 0;

            string currencyCross = (from + to).ToUpper();

            foreach (var key in CurrencyRates.Keys)
            {
                if (key.Equals(currencyCross))
                {
                    return CurrencyRates[key] * amount;
                }   
            }
            return 0;
        }
        
        private Dictionary<string, decimal> CurrencyRates = new Dictionary<string, decimal>()
        {
            {"USDEUR", 0.92M},
            {"USDGBP", 0.77M},
            {"USDDKK", 6.88M},

            {"EURUSD", 1.08M},
            {"EURGBP", 0.83M},
            {"EURDKK", 7.44M},

            {"GBPUSD", 1.31M},
            {"GBPEUR", 1.21M},
            {"GBPDKK", 8.99M},

            {"DKKUSD", 0.15M},
            {"DKKEUR", 0.13M},
            {"DKKGBP", 0.11M}
        };

    }
}
