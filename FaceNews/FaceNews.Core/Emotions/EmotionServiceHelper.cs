

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace FaceNews.Core
{
    /// <summary>
    /// Shared service helpers.
    /// </summary>
    public static class EmotionServiceHelper
    {

        /// <summary>
        /// WCFs the inquiry asynchronous.
        /// </summary>
        /// <param name="methodRequestType">Type of the method request.</param>
        /// <param name="service">The service.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="content">The content.</param>
        /// <returns>The result of the inquiry</returns>
		public static async Task<EmotionResponse> SendAync(HttpMethod methodRequestType, string service,byte[] content, string methodName = "")
        {
			string serviceUri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize";

            try
            {
                HttpClient httpClient = new HttpClient();
				HttpRequestMessage request = new HttpRequestMessage(methodRequestType, serviceUri)
				{

					Content = new ByteArrayContent(content: content)
				};
				request.Headers.Add("Ocp-Apim-Subscription-Key", "caf093b8b27544ea8b0815d769d638cf");
				request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                

                HttpResponseMessage response = await httpClient.SendAsync(request);
                string returnString = await response.Content.ReadAsStringAsync();
				var res = JsonConvert.DeserializeObject<List<EmotionResponse>>(returnString);
                return res[0];

            }
            catch (Exception)
            {
				return null;
            }
        }

        /// <summary>
        /// Gets the json request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The request formated as Json</returns>
        public static string SerializeJson(object request)
        {
            return JsonConvert.SerializeObject(request, GetSerializationSettings());
        }

        /// <summary>
        /// Gets the json response.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The deserialized response of type T</returns>
        public static T DeserializeJson<T>(string response)
        {
            return JsonConvert.DeserializeObject<T>(response, GetSerializationSettings());
        }

        /// <summary>
        /// Gets the serialization settings.
        /// </summary>
        /// <returns>The Serialization Settings</returns>
        private static JsonSerializerSettings GetSerializationSettings()
        {
            return new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
        }
    }
}
