using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews.Core
{
    /// <summary>
    /// document class for request and response body
    /// </summary>
    public class Document
    {
       /// <summary>
       /// For Text Analysis
       /// </summary>
       public int id { get; set; }
       public double score { get; set; }
       public string text { get; set; }
       public string language { get; set; }
    }
}
