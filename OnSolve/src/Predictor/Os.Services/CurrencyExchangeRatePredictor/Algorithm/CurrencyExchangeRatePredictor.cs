using System.Collections.Generic;
using Os.Services.Api.Base;
using Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate;

namespace Os.Services.CurrencyExchangeRatePredictor.Algorithm
{
    public abstract class CurrencyExchangeRatePredictor : ICurrencyExchangeRatePredictor
    {
        protected ICurrencyExchangeRateApiProvider apiProvider;

        public CurrencyExchangeRatePredictor(ICurrencyExchangeRateApiProvider apiProvider)
        {
            this.apiProvider = apiProvider;
        }

        public ICurrencyExchangeRateModel GeneratePredictModel(string fromCurrency, string toCurrency)
        {
            // Step 1: Collect sample data
            var historyData = CollectSampleHistoryData(fromCurrency, toCurrency);
            
            // Step 2: Generate model based on the collected data
            return GeneratePredictModel(historyData);
        }

        /// <summary>
        /// Collect history exchange rates. Using api provider to do this.
        /// </summary>
        /// <param name="fromCurrency">Source currency code</param>
        /// <param name="toCurrency">Target currency code</param>
        protected abstract Dictionary<int, double> CollectSampleHistoryData(string fromCurrency, string toCurrency);

        /// <summary>
        /// Generate a model of currency exchange rate predicting from the collected sample data.
        /// </summary>
        /// <param name="historyData">Collected data</param>
        protected abstract ICurrencyExchangeRateModel GeneratePredictModel(Dictionary<int, double> historyData);
    }
}