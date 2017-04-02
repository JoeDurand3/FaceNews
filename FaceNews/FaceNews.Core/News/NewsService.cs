using System;
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

        public async Task<NewsResponse> GetNewsAsync(string newsCategory = "")
        {
            dynamic resp;
            if (newsCategory != "")
                resp = await NewsServiceHelper.SendAync<NewsResponse>(Constants.NewsAPIURL, newsCategory);
            else
                resp = await NewsServiceHelper.SendAync<NewsResponse>(Constants.NewsAPIURL);
            return resp;

            foreach (Article a in resp.value)
            {
                a.image.imgdata = await ServiceHelper.DownloadRemoteImageFile(a.image.thumbnail.contentUrl);
            }

          
        }
    }
}
