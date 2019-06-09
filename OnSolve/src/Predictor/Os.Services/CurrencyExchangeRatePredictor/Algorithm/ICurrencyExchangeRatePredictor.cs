using Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate;

namespace Os.Services.CurrencyExchangeRatePredictor.Algorithm
{
    public interface ICurrencyExchangeRatePredictor
    {
        /// <summary>
        /// Generate a currency exchange rate predict model
        /// </summary>
        /// <param name="fromCurrency">Source currency code</param>
        /// <param name="toCurrency">Target currency code</param>
        /// <returns>A predict model that can be used to predict future exchange rate</returns>
        ICurrencyExchangeRateModel GeneratePredictModel(string fromCurrency, string toCurrency);
    }
}