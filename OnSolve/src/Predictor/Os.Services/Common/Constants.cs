using System;

namespace Os.Services.Common
{
    public static class Constants
    {
        public static readonly string[] CountryCodes =
        {
            "AED","AFN","ALL","AMD","ANG","AOA","ARS","AUD","AWG","AZN","BAM","BBD","BDT","BGN","BHD","BIF","BMD",
            "BND","BOB","BRL","BSD","BTC","BTN","BTS","BWP","BYN","BZD","CAD","CDF","CHF","CLF","CLP","CNH","CNY",
            "COP","CRC","CUC","CUP","CVE","CZK","DASH","DJF","DKK","DOGE","DOP","DZD","EAC","EGP","EMC","ERN","ETB",
            "ETH","EUR","FCT","FJD","FKP","FTC","GBP","GEL","GGP","GHS","GIP","GMD","GNF","GTQ","GYD","HKD","HNL",
            "HRK","HTG","HUF","IDR","ILS","IMP","INR","IQD","IRR","ISK","JEP","JMD","JOD","JPY","KES","KGS","KHR",
            "KMF","KPW","KRW","KWD","KYD","KZT","LAK","LBP","LD","LKR","LRD","LSL","LTC","LYD","MAD","MDL","MGA",
            "MKD","MMK","MNT","MOP","MRO","MRU","MUR","MVR","MWK","MXN","MYR","MZN","NAD","NGN","NIO","NMC","NOK",
            "NPR","NVC","NXT","NZD","OMR","PAB","PEN","PGK","PHP","PKR","PLN","PPC","PYG","QAR","RON","RSD","RUB",
            "RWF","SAR","SBD","SCR","SDG","SEK","SGD","SHP","SLL","SOS","SRD","SSP","STD","STN","STR","SVC","SYP",
            "SZL","THB","TJS","TMT","TND","TOP","TRY","TTD","TWD","TZS","UAH","UGX","USD","UYU","UZS","VEF","VEF_BLKMKT",
            "VEF_DICOM","VEF_DIPRO","VES","VND","VTC","VUV","WST","XAF","XAG","XAU","XCD","XDR","XMR","XOF","XPD",
            "XPF","XPM","XPT","XRP","YER","ZAR","ZMW","ZWL"
        };

        public static readonly DateTime PrimaryPredictDate = new DateTime(2016, 01, 15);

        public static readonly string DateFormat = "dd/MM/yyyy";
    }
}