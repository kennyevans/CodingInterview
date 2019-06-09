using System.Linq;
using NUnit.Framework;
using Os.Services.Api.OpenExchangeRates;
using Os.Services.CurrencyExchangeRatePredictor;
using Os.Services.CurrencyExchangeRatePredictor.Algorithm;
using Os.Services.CurrencyExchangeRatePredictor.ServiceMessages;

namespace Os.IntegrationTests.CurrencyExchangeRatePredictor
{
    [TestFixture]
    public class CurrencyExchangeRatePredictorSpec
    {
        #region Common Methods

        public static GeneratePredictModelRequest CreateGeneratePredictModelRequest()
        {
            return new GeneratePredictModelRequest("USD", "TRY", new LinearRegressionRatePredictor(new OpenExchangeRatesApiProvider()));
        }
        
        #endregion
        
        [Test]
        public void CurrencyExchangeRatePredictor_GeneratePredictModel_BaseTest()
        {
            // Arrange
            var request = CreateGeneratePredictModelRequest();
           
            // Act
            var response = new CurrencyExchangePredictorService().GeneratePredictModel(request);
            
            // Assert
            Assert.IsNotNull(response);
            Assert.IsFalse(response.AtLeastError, "At least error");
        }
        
        [Test]
        public void CurrencyExchangeRatePredictor_GeneratePredictModel_Validate_MandatoryTest()
        {
            // Arrange
            var request = CreateGeneratePredictModelRequest();
            request.FromCurrency = string.Empty;
            request.ToCurrency = string.Empty;
            
            // Act
            var response = new CurrencyExchangePredictorService().GeneratePredictModel(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Messages.Count(x => x.IsError) == 2, "Error messages count");
            Assert.IsTrue(response.Messages.First(x => x.IsError).Code == "OS-0001", "First error message code");
            Assert.IsTrue(response.Messages.Last(x => x.IsError).Code == "OS-0001", "Second error message code");
        }
        
        [Test]
        public void CurrencyExchangeRatePredictor_GeneratePredictModel_Validate_NotAValidValueTest()
        {
            // Arrange
            var request = CreateGeneratePredictModelRequest();
            request.FromCurrency = "N/A";
            request.ToCurrency = "N/A";
            
            // Act
            var response = new CurrencyExchangePredictorService().GeneratePredictModel(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Messages.Count(x => x.IsError) == 2, "Error messages count");
            Assert.IsTrue(response.Messages.First(x => x.IsError).Code == "OS-0002", "First error message code");
            Assert.IsTrue(response.Messages.Last(x => x.IsError).Code == "OS-0002", "Second error message code");
        }
        
        [Test]
        public void CurrencyExchangeRatePredictor_GeneratePredictModel_ApiOnlySupportedUSDBaseCurrencyTest()
        {
            // Arrange
            var request = CreateGeneratePredictModelRequest();
            request.FromCurrency = "TRY";
            request.ToCurrency = "USD";
            
            // Act
            var response = new CurrencyExchangePredictorService().GeneratePredictModel(request);

            // Assert
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Messages.Count(x => x.IsError) == 1, "Error messages count");
            Assert.IsTrue(response.Messages.First(x => x.IsError).Code == "OS-0003", "First error message code");
        }
    }
}