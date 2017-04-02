using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    /// <summary>
    /// List of documents used to make up the API request 
    /// </summary>
    class TextAnalyticsRequest
    {
        public List<Document> documents { get; set; }

    }
}
