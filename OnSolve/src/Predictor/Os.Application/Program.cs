using System;
using System.Linq;
using System.Threading;
using Os.Services.Api.OpenExchangeRates;
using Os.Services.Common;
using Os.Services.CurrencyExchangeRatePredictor;
using Os.Services.CurrencyExchangeRatePredictor.Algorithm;
using Os.Services.CurrencyExchangeRatePredictor.ServiceMessages;

namespace Os.Application
{
    /*********************************************
     * Author: Khoa Nguyen Van
     * Contact: khoavantdt@gmail.com
     *********************************************/
    
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(">>>>> CURRENCY EXCHANGE RATE PREDICTOR <<<<<");
            Console.WriteLine();

            do
            {
                Console.Write("From Currency = ");
                var fromCurrency = Console.ReadLine();
                Console.Write("To Currency = ");
                var toCurrency = Console.ReadLine();

                Console.WriteLine(">>>>> I'm predicting...");
                Thread.Sleep(2000);
                Console.WriteLine(Comedian.TellAJoke());

                var request = new GeneratePredictModelRequest(fromCurrency, toCurrency, new LinearRegressionRatePredictor(new OpenExchangeRatesApiProvider()));
                var response = new CurrencyExchangePredictorService().GeneratePredictModel(request);
                if (response.AtLeastError)
                    Console.WriteLine(">> Encountered error(s): \n" + response.Messages.Where(x => x.IsError).AsText());
                else
                {
                    Thread.Sleep(4000);
                    var predictDate = new DateTime(2017, 01, 15);
                    var model = response.Model;
                    var exchangeRate = model.PredictFutureRate(predictDate);
                    Console.WriteLine($">> Well, I guess the rate is {exchangeRate} at {predictDate.ToString(Constants.DateFormat)} exchanging from {fromCurrency.ToUpper()} to {toCurrency.ToUpper()}");
                }
                
                Console.ReadLine();

            } while (true);
        }
    }
}