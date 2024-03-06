using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            var client = new HttpClient();

            var quote = new RonVSKanyeAPI(client);

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine($"Kanye: {quote.KanyeQuote()}");

                Console.WriteLine($"Ron: {quote.RonQuote()}");

            }

            Console.WriteLine("--------------");


            Console.Write("Enter your API key: ");
            string apiKey = Console.ReadLine();

            Console.Write("Enter the city name: ");
            string city = Console.ReadLine();

            OpenWeatherMapAPI weatherService = new OpenWeatherMapAPI();
            weatherService.GetWeather(apiKey, city);






        }
    }
}
