﻿using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
        /// WCFs the inquiry asynchronous.
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

        private static void DownloadRemoteImageFile(string uri, string fileName)
        {

            HttpRequestMessage req = new HttpRequestMessage(method: HttpMethod.Post, requestUri: uri);
            


         /*   HttpRequestMessage request = (HttpWebRequest)WebRequest.Create(uri);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();*/

            // Check that the remote file was found. The ContentType
            // check is performed since a request for a non-existent
            // image file might be redirected to a 404-page, which would
            // yield the StatusCode "OK", even though the image was not
            // found.
           /* if ((response.StatusCode == HttpStatusCode.OK ||
                response.StatusCode == HttpStatusCode.Moved ||
                response.StatusCode == HttpStatusCode.Redirect) &&
                response.ContentType.StartsWith("image", StringComparison.OrdinalIgnoreCase))
            {

                // if the remote file was found, download oit
                using (Stream inputStream = response.GetResponseStream())
                using (Stream outputStream = File.OpenWrite(fileName))
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead;
                    do
                    {
                        bytesRead = inputStream.Read(buffer, 0, buffer.Length);
                        outputStream.Write(buffer, 0, bytesRead);
                    } while (bytesRead != 0);
                }
            }*/
        }
    }
}
