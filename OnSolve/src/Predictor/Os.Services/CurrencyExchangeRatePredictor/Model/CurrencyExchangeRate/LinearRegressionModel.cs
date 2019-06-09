using System;
using Os.Services.Common;

namespace Os.Services.CurrencyExchangeRatePredictor.Model.CurrencyExchangeRate
{
    public class LinearRegressionModel : ICurrencyExchangeRateModel
    {
        public LinearRegressionModel(double slope, double intercept)
        {
            this.slope = slope;
            this.intercept = intercept;
        }

        private double slope;
        
        private double intercept;

        /// <summary>
        /// Calculate exchange rate for a specific future date
        /// </summary>
        public double PredictFutureRate(DateTime atDate)
        {
            var xVariable = ConvertDateToVariableX(atDate);
            return CalculateRegression(xVariable);
        }

        private int ConvertDateToVariableX(DateTime atDate)
        {
            var calDate = new DateTime(atDate.Year, atDate.Month, Constants.PrimaryPredictDate.Day);
            return (int)(calDate.Subtract(Constants.PrimaryPredictDate).TotalDays / 30) + 1;
        }

        /// <summary>
        /// regression(y) = slope(a) + intercept(b)*x
        /// </summary>
        private double CalculateRegression(int xVariable)
        {
            return Math.Round(slope + intercept * xVariable, 3);
        }
    }
}