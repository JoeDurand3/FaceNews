using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    /// <summary>
    /// Helper Class for News Retrieve/Receive
    /// </summary>
    public class NewsResponse
    {
        public List<Article> value { get; set; }
    }
}
