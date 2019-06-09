using System;

namespace Os.Services.Api.Base
{
    public interface ICurrencyExchangeRateApiProvider
    {
        /// <summary>
        /// Return an exchange rate between 2 currencies at a specific date.
        /// </summary>
        /// <param name="date">History date</param>
        /// <param name="fromCurrencyCode">Source currency code</param>
        /// <param name="toCurrencyCode">Target currency code</param>
        /// <returns>Exchange Rate</returns>
        double GetHistoryExchangeRate(DateTime date, string fromCurrencyCode, string toCurrencyCode);
    }
}