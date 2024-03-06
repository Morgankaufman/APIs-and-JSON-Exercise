using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;


namespace APIsAndJSON
{
    public class OpenWeatherMapAPI
    {
        public void GetWeather(string apiKey, string city)
        {
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=imperial&appid={apiKey}";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = response.Content.ReadAsStringAsync().Result;
                    dynamic data = JObject.Parse(responseBody);

                    string cityName = data.name;
                    double temperature = data.main.temp;
                    string weatherDescription = data.weather[0].description;

                    Console.WriteLine($"Current Weather in {cityName}:");
                    Console.WriteLine($"Temperature: {temperature} °F");
                    Console.WriteLine($"Description: {weatherDescription}");
                }
                else
                {
                    Console.WriteLine($"Failed to retrieve weather data. Status code: {response.StatusCode}");
                }
            }





        }
    }
}



