using System;
using Newtonsoft.Json.Linq;
using System.Net.Http;



namespace APIsAndJSON
{
    public class RonVSKanyeAPI
    {
        private HttpClient _client;
       
        public RonVSKanyeAPI(HttpClient client)
        {
            _client = client;
        }

        public string KanyeQuote()
        {
            
            var kanyeURL = "https://api.kanye.rest";

            var kanyeResponse = _client.GetStringAsync(kanyeURL).Result;

            var kanyeQuote = JObject.Parse(kanyeResponse).GetValue("quote").ToString();

            return kanyeQuote;
        }

        public string RonQuote()
        {
            
            var ronURL = "https://ron-swanson-quotes.herokuapp.com/v2/quotes";

            var ronResponse = _client.GetStringAsync(ronURL).Result;

            var ronQuote = JArray.Parse(ronResponse);

            return ronQuote[0].ToString();
        }
        
    }
}
