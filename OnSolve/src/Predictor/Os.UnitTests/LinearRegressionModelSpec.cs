using System;
using NUnit.Framework;
using Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate;

namespace Os.UnitTests
{
    [TestFixture]
    public class LinearRegressionModelSpec
    {
        [Test]
        public void LinearRegressionModel_PredictFutureRateTest()
        {
            var linearRegressionModel = new LinearRegressionModel(10, 2);
            var rate = linearRegressionModel.PredictFutureRate(new DateTime(2017, 8, 15));
            Assert.AreEqual(50d, rate, "Predicted exchange rate");
        }
    }
}