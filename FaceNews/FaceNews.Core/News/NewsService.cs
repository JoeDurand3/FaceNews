﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    public class NewsService
    {
        /// <summary>
        /// Gets the static instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static NewsService Instance { get; } = new NewsService();



        private NewsService()
        {
        }

        /// <summary>
        /// Send Different type of Request to Bing News Search API
        /// </summary>
        /// <param name="newsCategory"></param>
        /// <returns></returns>
        public async Task<NewsResponse> GetNewsAsync(string newsCategory = "")
        {
            dynamic resp;
            if (newsCategory != "")
                resp = await NewsServiceHelper.SendAync<NewsResponse>(Constants.NewsAPIURL, newsCategory);
            else
                resp = await NewsServiceHelper.SendAync<NewsResponse>(Constants.NewsAPIURL);
            return resp;
        }
    }
}
