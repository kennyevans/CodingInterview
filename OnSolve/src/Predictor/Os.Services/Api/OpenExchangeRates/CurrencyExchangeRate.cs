using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Os.Services.Api.OpenExchangeRates
{
    /// <summary>
    /// Represent to Open Exchange Rate Historical api response
    /// </summary>
    public partial class CurrencyExchangeRate
    {
        [JsonProperty("disclaimer")]
        public string Disclaimer { get; set; }

        [JsonProperty("license")]
        public Uri License { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("base")]
        public string Base { get; set; }

        [JsonProperty("rates")]
        public Dictionary<string, double> Rates { get; set; }
    }

    public partial class CurrencyExchangeRate
    {
        public double GetExchangeRate(string toCurrencyCode)
        {
            if (Rates == null) return 0;
            
            return Rates.TryGetValue(toCurrencyCode.ToUpper(), out var rate) ? rate : 0;
        }
    }

    public partial class CurrencyExchangeRate
    {
        public static CurrencyExchangeRate FromJson(string json) => JsonConvert.DeserializeObject<CurrencyExchangeRate>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this CurrencyExchangeRate self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}