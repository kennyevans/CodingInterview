using System;
using System.Collections.Generic;
using Os.Services.Api.Base;
using Os.Services.Common;
using Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate;

namespace Os.Services.CurrencyExchangeRatePredictor.Algorithm
{
    public class LinearRegressionRatePredictor : CurrencyExchangeRatePredictor
    {
        public LinearRegressionRatePredictor(ICurrencyExchangeRateApiProvider apiProvider) : base(apiProvider) { }

        /// <summary>
        /// Collect history exchange rates each month of a year
        /// </summary>
        /// <param name="fromCurrency">Source currency code</param>
        /// <param name="toCurrency">Target currency code</param>
        protected override Dictionary<int, double> CollectSampleHistoryData(string fromCurrency, string toCurrency)
        {
            var data = new Dictionary<int, double>();
            for (int month = 1; month <= 12; month++)
            {
                var atDate = new DateTime(Constants.PrimaryPredictDate.Year, month, Constants.PrimaryPredictDate.Day);
                var rate = apiProvider.GetHistoryExchangeRate(atDate, fromCurrency, toCurrency);

                data.Add(month, rate);
            }

            return data;
        }
        
        /// <summary>
        /// Using simple linear regression statistic method for the prediction.
        /// See <a href="https://www.easycalculation.com/statistics/learn-regression.php">here</a> for more details.
        /// </summary>
        /// <param name="historyData">Collected data</param>
        protected override ICurrencyExchangeRateModel GeneratePredictModel(Dictionary<int, double> historyData)
        {
            double nr = 0, dr = 0, slope, intercept;
            double[] xx, xy, yy;
            xx = new double[historyData.Count];
            xy = new double[historyData.Count];
            yy = new double[historyData.Count];
            
            double[] x = new double[historyData.Count], y = new double[historyData.Count];
            var count = 0;
            foreach (var data in historyData)
            {
                x[count] = data.Key;
                y[count] = data.Value;
                count++;
            }
            
            double sum_y = 0, sum_xy = 0, sum_x = 0, sum_xx = 0, sum_x2 = 0;
            
            int i, n = historyData.Count;
            for (i = 0; i < n; i++)
            {
                xx[i] = x[i] * x[i];
                yy[i] = y[i] * y[i];
            }

            for (i = 0; i < n; i++)
            {
                sum_x += x[i];
                sum_y += y[i];
                sum_xx += xx[i];
                sum_xy += x[i] * y[i];
            }

            nr = (n * sum_xy) - (sum_x * sum_y);
            sum_x2 = sum_x * sum_x;
            dr = (n * sum_xx) - sum_x2;
            
            slope = nr / dr;
            intercept = (sum_y - slope * sum_x) / n;

            return new LinearRegressionModel(intercept, slope);
        }
    }
}