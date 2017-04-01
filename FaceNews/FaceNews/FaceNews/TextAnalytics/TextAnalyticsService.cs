﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews
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
        /// <param name="citizenId">The citizen identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public async Task<SentimentResponse> GetTextAnalyticsAsync(string textId, string textBody )
        {

            var req = new TextAnalyticsRequest();
            req.documents = new List<Document>();
            req.documents.Add(new Document
            {
                language = Constants.languages,
                id = textId,
                text = textBody
            });

           return await ServiceHelper.SendAync<SentimentResponse>(
             Constants.TextAnalyticsAPIURL, "sentiment", req);

        }
    }
}
