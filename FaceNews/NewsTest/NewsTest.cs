using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NewsTest
{
    static class NewsTest
    {
        static void Main()
        {
            MakeRequest();
            Console.WriteLine("Hit ENTER to exit...");
            Console.ReadLine();
        }

        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b5a9bf01dfea44ac81e18b59a7dbedc6");

            // Request parameters
            //queryString["Category"] = "US";
            var uri = "https://api.cognitive.microsoft.com/bing/v5.0/news/";// + queryString;

            var newsResponse = await client.GetAsync(uri);
            String res = await newsResponse.Content.ReadAsStringAsync();
            Console.Write(res);

        }
    }
}