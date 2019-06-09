using Os.Services.Common;
using Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate;

namespace Os.Services.CurrencyExchangeRatePredictor.ServiceMessages
{
    public class GeneratePredictModelResponse : ValueObjectBase
    {
        /// <summary>
        /// A model that can be used to predict exchange rate
        /// </summary>
        public ICurrencyExchangeRateModel Model { get; set; }
    }
}