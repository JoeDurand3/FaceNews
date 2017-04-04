using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.IO;

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
            //"default" emotions:
            _emotions = new EmotionResponse
            {
                scores = new Scores
                {
                    happiness = 0.5
                }
            };

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
				var arts = emotionalNewsInterface(_allArticles, _emotions.scores.happiness);
				currentArticles.Clear();

                foreach (Article a in arts)
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
                var error = await EmotionProcessingLogic.Instance.TakePicture();
                var byteRA = ReadFully(EmotionProcessingLogic.Instance.MediaFile.GetStream());
				_emotions = await EmotionService.getEmotion(byteRA);
                return null;
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        /// <summary>
        /// Determines the list of articles for the user, based on their happiness.
        /// TODO: Update algorithm to consider more emotions than just happiness!
        /// </summary>
        /// <param name="articles"></param>
        /// <param name="happiness"></param>
        /// <returns></returns>
        private List<Article> emotionalNewsInterface(List <Article> articles, double happiness)
		{
            var newArts = new List<Article>();

            if (happiness >= 0.7)
            {
                newArts = articles.Where<Article>(art => art.sentiment <= 0.3).ToList();
            }
            else if (happiness >= 0.3)
            {
                newArts = articles.Where<Article>(art => art.sentiment > 0.3 && art.sentiment < 0.7).ToList();
            }
            else
            {
                newArts = articles.Where<Article>(art => art.sentiment >= 0.7).ToList();
            }

            return newArts;
        }

        /// <summary>
        /// convert a stream into a byte array.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
