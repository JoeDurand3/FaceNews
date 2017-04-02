using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using Xamarin.Forms;

using System.IO;

namespace FaceNews.Core
{
    /// <summary>
    /// Shared service helpers.
    /// </summary>
    public static class ServiceHelper
    {
        /// <summary>
        /// Inquires the specified service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="service">The service.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="request">The request object.</param>
        /// <returns></returns>
        public static async Task<T> SendAync<T>(string service, string methodName, object request)
        {
            string json = SerializeJson(request);
            string result = await SendAsync(HttpMethod.Post, service, methodName, json);

            return DeserializeJson<T>(result);
        }

        /// <summary>
        /// Asynchronous data push
        /// </summary>
        /// <param name="methodRequestType">Type of the method request.</param>
        /// <param name="service">The service.</param>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="content">The content.</param>
        /// <returns>The result of the inquiry</returns>
        private static async Task<string> SendAsync(HttpMethod methodRequestType, string service, string methodName,
            string content = "")
        {
            try
            {
                string serviceUri = service + methodName;
                HttpClient httpClient = new HttpClient();
                HttpRequestMessage request = new HttpRequestMessage(methodRequestType, serviceUri)
                {
                    Content = new StringContent(content, Encoding.UTF8, "application/json")
                };
                request.Headers.Add("Ocp-Apim-Subscription-Key", Constants.TextAnalyticsAPIKey);

                HttpResponseMessage response = await httpClient.SendAsync(request);
                string returnString = await response.Content.ReadAsStringAsync();
                return returnString;
            }
            catch (Exception)
            {
                return string.Empty;
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

        public static async Task<ImageSource> DownloadRemoteImageFile(string uri)
        {
            HttpClient client = new HttpClient();
            byte[] byteArray = await client.GetByteArrayAsync(uri);
            return ImageSource.FromStream(() => new MemoryStream(byteArray));
        }
    }
}
