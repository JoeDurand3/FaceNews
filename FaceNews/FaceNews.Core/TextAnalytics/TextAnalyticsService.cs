using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    public class TextAnalyticsService
    {
        /// <summary>
        /// Gets the static instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
       public static TextAnalyticsService Instance { get; } = new TextAnalyticsService();

      
       
        private TextAnalyticsService()
        {
        }

        /// <summary>
        /// Gets the citizen bank balance asynchronous.
        /// </summary>
        /// <param name="textId">The body identifier.</param>
        /// <param name="textBody">The text to be analyzed.</param>
        /// <returns></returns>
        public async Task<SentimentResponse> GetTextAnalyticsAsync(List<Document> documents)
        {

            var req = new TextAnalyticsRequest();
            req.documents = documents;

           return await ServiceHelper.SendAync<SentimentResponse>(
             Constants.TextAnalyticsAPIURL, "sentiment", req);

        }
    }
}
