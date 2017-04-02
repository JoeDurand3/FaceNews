using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    //document class for request and response body
    public class Document
    {
       //For TextAnalytics
       public int id { get; set; }
       public double score { get; set; }
       public string text { get; set; }
       public string language { get; set; }
    }
}
