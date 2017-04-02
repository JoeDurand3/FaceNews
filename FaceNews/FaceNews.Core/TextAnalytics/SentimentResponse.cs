using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{ 
    //List of Document and Error objects for API calls with multiple elements
    public class SentimentResponse
    {
        public List<Document> documents { get; set; }
        public List<Error> errors { get; set; }
    }
}
