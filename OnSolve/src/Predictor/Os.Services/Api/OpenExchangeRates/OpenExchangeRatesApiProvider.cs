using System;
using Os.Services.Api.Base;

namespace Os.Services.Api.OpenExchangeRates
{
    public class OpenExchangeRatesApiProvider : OpenExchangeRatesApiClient, ICurrencyExchangeRateApiProvider
    {
        public double GetHistoryExchangeRate(DateTime date, string fromCurrencyCode, string toCurrencyCode)
        {
            var currencyExchangeRate = this.GetHistoryExchangeRate(date, fromCurrencyCode);

            return currencyExchangeRate.GetExchangeRate(toCurrencyCode);
        }
    }
}