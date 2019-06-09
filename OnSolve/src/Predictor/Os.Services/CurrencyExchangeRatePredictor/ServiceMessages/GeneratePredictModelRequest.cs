using Os.Services.Common;
using Os.Services.CurrencyExchangeRatePredictor.Algorithm;

namespace Os.Services.CurrencyExchangeRatePredictor.ServiceMessages
{
    public class GeneratePredictModelRequest : ValueObjectBase
    {
        public GeneratePredictModelRequest(string fromCurrency, string toCurrency, ICurrencyExchangeRatePredictor predictor)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Predictor = predictor;
        }

        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        /// <summary>
        /// A method used to predict, the returned model is based on this one. 
        /// </summary>
        public ICurrencyExchangeRatePredictor Predictor { get; set; }
    }
}