using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;

namespace TextAnalyticsTest
{
    static class TextAnalyticsTest
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
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "421758dba6144f09a4ebe472f54bc034");

            //// Request parameters
            //queryString["numberOfLanguagesToDetect"] = "1";
            var uri = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/sentiment";// + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\"documents\": [{\"language\": \"en\",\"id\": \"1\",\"text\": \"First document\"}]}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                String res = await response.Content.ReadAsStringAsync();
                Console.Write(res);
            }

        }
    }
}