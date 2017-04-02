using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FaceNews.Core.BusinessLogic
{
    public class NewsEmotionLogic
    {
        private List<Article> _allArticles = null;
        private int _happiness = 7;

        public ObservableCollection<Article> currentArticles = new ObservableCollection<Article>();

        /// <summary>
        /// Gets the happiness.
        /// </summary>
        /// <value>
        /// The happiness.
        /// </value>
        public int happiness
        {
            get
            {
                return _happiness;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static NewsEmotionLogic Instance { get; } = new NewsEmotionLogic();

        /// <summary>
        /// Prevents a default instance of the <see cref="NewsEmotionLogic"/> class from being created.
        /// </summary>
        private NewsEmotionLogic()
        {

        }

        public async Task<String> downloadStories()
        {
            try
            {
                _allArticles = await NewsProcessingLogic.Instance.processArticles();

                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Updates the happiness stories.
        /// </summary>
        /// <returns></returns>
        public async Task<string> updateStories()
        {
            try
            {
                var arts = emotionalNewsInterface(_allArticles, _happiness);
                currentArticles.Clear();

                /*foreach (Article a in arts)
                {
                    currentArticles.Add(a);
                }*/
                foreach (Article a in _allArticles)
                {
                    currentArticles.Add(a);
                }
                return null;
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Calculates the stories.
        /// </summary>
        /// <returns></returns>
        public async Task<string> updateHappiness()
        {
            try
            {
                byte[] face = await EmotionProcessingLogic.Instance.getImage();
                _happiness = await EmotionService.getEmotion(face);
                return null;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        private List<Article> emotionalNewsInterface(List <Article> articles, int happiness)
        {
            var list = new List<Article>();

            if (happiness >= 7)
            {
                return articles.Where<Article>(art => art.sentiment <= 3).ToList();
            }
            else if (happiness >= 3)
            {
                return articles.Where<Article>(art => art.sentiment > 3 && art.sentiment < 7).ToList();
            }
            else
            {
                return articles.Where<Article>(art => art.sentiment >= 7).ToList();
            }
        }

    }
}
