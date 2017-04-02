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
		private List<Article> _allArticles = new List<Article>();
		private EmotionResponse _emotions = new EmotionResponse();

        public ObservableCollection<Article> currentArticles = new ObservableCollection<Article>();

        /// <summary>
        /// Gets the happiness.
        /// </summary>
        /// <value>
        /// The happiness.
        /// </value>
        public EmotionResponse emotions
        {
            get
            {
                return _emotions;
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
				var arts = emotionalNewsInterface(_allArticles, (int)_emotions.scores.happiness);
				currentArticles.Clear();

				for (int i = 0; i < arts.Count; i++)
				{
					currentArticles.Add(arts[i]);
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
                
				_emotions = await EmotionService.getEmotion(face);
                return null;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        private List<Article> emotionalNewsInterface(List <Article> articles, int happiness)
		{
			var newArts = new List<Article>();

			foreach (Article a in articles)
			{
				newArts.Add(a.clone());
			}

            if (happiness >= 7)
            {
				return newArts.Where<Article>(art => art.sentiment <= 3).ToList();
            }
            else if (happiness >= 3)
            {
                return newArts.Where<Article>(art => art.sentiment > 3 && art.sentiment < 7).ToList();
            }
            else
            {
                return newArts.Where<Article>(art => art.sentiment >= 7).ToList();
            }
        }

    }
}
