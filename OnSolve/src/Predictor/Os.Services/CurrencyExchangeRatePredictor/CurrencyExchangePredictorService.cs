using System;
using Os.Services.Common;
using Os.Services.CurrencyExchangeRatePredictor.ServiceMessages;
using Os.Services.Text;

namespace Os.Services.CurrencyExchangeRatePredictor
{
    public class CurrencyExchangePredictorService
    {
        /// <summary>
        /// Generate a model that can be used to predict exchange rate.
        /// The generated model is based on predict method specified in request.
        /// </summary>
        public GeneratePredictModelResponse GeneratePredictModel(GeneratePredictModelRequest request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));
            var response = new GeneratePredictModelResponse();

            // Validate request data
            Validate(request, response);

            // Stop if any error encountered
            if (response.AtLeastError) return response;
            
            // Actual generate predict model
            InternalGeneratePredictModel(request, response);

            return response;
        }

        /// <summary>
        /// Validate required fields
        /// </summary>
        private void Validate(GeneratePredictModelRequest request, GeneratePredictModelResponse response)
        {
            // From currency code is mandatory
            if (request.FromCurrency.IsBlank())
                response.Messages.Add(new CurrencyExchangePredictorMessages.Mandatory("From Currency Code"));
            
            // From currency code must be valid
            else if (!request.FromCurrency.IsAValidCountryCode())
                response.Messages.Add(new CurrencyExchangePredictorMessages.NotAValidValue("Currency Code", request.FromCurrency));

            // To currency code is mandatory
            if (request.ToCurrency.IsBlank())
                response.Messages.Add(new CurrencyExchangePredictorMessages.Mandatory("To Currency Code"));
            
            // To currency code must be valid
            else if (!request.ToCurrency.IsAValidCountryCode())
                response.Messages.Add(new CurrencyExchangePredictorMessages.NotAValidValue("Currency Code", request.ToCurrency));
        }

        /// <summary>
        /// Actual generate a predict model
        /// </summary>
        private void InternalGeneratePredictModel(GeneratePredictModelRequest request, GeneratePredictModelResponse response)
        {
            try
            {
                var predictModel = request.Predictor.GeneratePredictModel(request.FromCurrency, request.ToCurrency);
                response.Model = predictModel;
            }
            catch (Exception e)
            {
                response.Messages.Add(new CurrencyExchangePredictorMessages.InternalError());
            }
        }
    }
}