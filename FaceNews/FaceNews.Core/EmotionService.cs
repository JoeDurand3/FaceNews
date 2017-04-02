using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    static class EmotionService
    {
        static void Main()
        {

            byte[] dataIn = Encoding.UTF8.GetBytes("{ \"url\": \"http://www.apimages.com/Images/Ap_Creative_Stock_Header.jpg\" }");
            getEmotion(dataIn);
        }

        static async Task<int> getEmotion(byte[] dataInput)
        {
            var client = new HttpClient();

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "caf093b8b27544ea8b0815d769d638cf");

            var uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";

            HttpResponseMessage response;

            // Request body
            byte[] byteData = dataInput;
            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                //application/json for url, application/octet-stream for binary data
                response = await client.PostAsync(uri, content);
                String res = await response.Content.ReadAsStringAsync();
                //Console.Write(res);
                dynamic x = Newtonsoft.Json.JsonConvert.DeserializeObject(res);
                var Scores = x[0].scores;
                double happy = Scores.happiness;
                //Happiness Algorithm
                if (happy > Scores.anger && happy > Scores.contempt && happy > Scores.disgust && happy > Scores.fear && happy > Scores.neutral && happy > Scores.sadness && happy > Scores.surprise)
                    return 3;
                else if (Scores.neutral > 0.5)
                    return 2;
                else
                    return 1;
                {
  
                }
            }

        }
    }
}