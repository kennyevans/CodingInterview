using System;
using System.Text;
using Os.Services.Api.Base;

namespace Os.Services.Api.OpenExchangeRates
{
    public class OpenExchangeRatesApiClient : ApiClient
    {
        private const string AppId = "9c88fc78c6454a94bcf08fca8cc0fae3";
        private const string BaseUrl = "https://openexchangerates.org/api/";
        private const string HistoricalUrl = @"historical/{0}.json?base={1}";
        private const string ApiDateFormat = "yyyy-MM-dd";

        private static readonly TimeSpan TimeOut = TimeSpan.FromSeconds(90);

        public OpenExchangeRatesApiClient() : base(BaseUrl, TimeOut)
        {
        }
        
        #region APIs
        
        /// <summary>
        /// GET: History Exchange Rate API
        /// </summary>
        public CurrencyExchangeRate GetHistoryExchangeRate(DateTime date, string fromCurrencyCode)
        {
            return this.GetAsync<CurrencyExchangeRate>(BuildHistoryExchangeRateUrl(date, fromCurrencyCode)).Result;
        }

        #endregion

        #region Utility

        private static string BuildHistoryExchangeRateUrl(DateTime date, string fromCurrencyCode)
        {
            return new StringBuilder()
                .Append(string.Format(HistoricalUrl, date.Date.ToString(ApiDateFormat), fromCurrencyCode.ToUpper()))
                .Append($"&app_id={AppId}")
                .ToString();
        }

        #endregion
    }
}