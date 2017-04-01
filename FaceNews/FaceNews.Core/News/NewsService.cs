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

        /// <summary>
        /// Gets the citizen bank balance asynchronous.
        /// </summary>
        /// <param name="citizenId">The citizen identifier.</param>
        /// <param name="vendorId">The vendor identifier.</param>
        /// <returns></returns>
        public async Task<NewsResponse> GetNewsAsync(/*string newsCategory*/)
        {
            return await NewsServiceHelper.SendAync<NewsResponse>(
              Constants.NewsAPIURL/*, newsCategory*/);

        }
    }
}
