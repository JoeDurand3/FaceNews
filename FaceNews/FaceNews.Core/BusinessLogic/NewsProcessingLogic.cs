using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FaceNews.Core;

namespace FaceNews.Core.BusinessLogic
{
    public class NewsProcessingLogic
    {
        private List<Article> articles = new List<Article>();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static NewsProcessingLogic Instance { get; } = new NewsProcessingLogic();

        /// <summary>
        /// Prevents a default instance of the <see cref="NewsProcessingLogic"/> class from being created.
        /// </summary>
        private NewsProcessingLogic()
        {

        }

        public async Task<List<Article>> processArticles()
        {
            var articles = await getArticles();
            articles = await evaluateArticles(articles);
            articles = sortArticles(articles);
            return articles;
        }

        /// <summary>
        /// Gets the articles.
        /// </summary>
        /// <returns></returns>
        private async Task<List<Article>> getArticles()
        {
            var resp = await NewsService.Instance.GetNewsAsync();
            return resp.value;
        }

        /// <summary>
        /// Evaluates the sentiment of the articles.
        /// </summary>
        /// <returns></returns>
        private async Task<List<Article>> evaluateArticles(List<Article> articles)
        {
            var docs = ArticleToDocumentHelper.toDocList(articles);
            var resp = await TextAnalyticsService.Instance.GetTextAnalyticsAsync(documents: docs);

            for (int i = 0; i < docs.Count; i++)
            {
                articles[i].sentiment = resp.documents[i].score;
            }

            return articles;
        }

        /// <summary>
        /// Sorts the articles based on their sentiment rating.
        /// Inversely proportions 
        /// </summary>
        /// <param name="weight">The weight.</param>
        /// <returns></returns>
        private List<Article> sortArticles(List<Article> articles)
        {
            var RA = articles.ToArray();
            Array.Sort(RA, delegate (Article a, Article b)
            {
                return a.sentiment.CompareTo(b.sentiment);
            });
            return RA.ToList<Article>();
        }

    }
}
