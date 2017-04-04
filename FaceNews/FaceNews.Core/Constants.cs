using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    class Constants
    {
        public static string TextAnalyticsAPIKey = "421758dba6144f09a4ebe472f54bc034";
        public static string EmotionAPIKey = "caf093b8b27544ea8b0815d769d638cf";
        public static string BingSearchKey = "b5a9bf01dfea44ac81e18b59a7dbedc6";
        public static string TextAnalyticsAPIURL = "https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/";
        public static string NewsAPIURL = "https://api.cognitive.microsoft.com/bing/v5.0/news/";
        public static string EmotionAPIURL = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize/";
        public static string languages = "en";
        public static String[] NewsCategories = { "Business", "Entertainment", "Health", "Politics", "ScienceAndTechnology", "Sports", "US/UK", "World" };
    }
}
