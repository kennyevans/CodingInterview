using System;

namespace Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate
{
    public interface ICurrencyExchangeRateModel
    {
        /// <summary>
        /// Predict currency exchange rate at a specific future date 
        /// </summary>
        /// <param name="atDate">Date at future wants to predict</param>
        double PredictFutureRate(DateTime atDate);
    }
}