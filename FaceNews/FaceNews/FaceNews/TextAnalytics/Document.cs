using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaceNews
{
    public class Document
    {
       //For TextAnalytics
       public string id { get; set; }
       public string score { get; set; }
       public string text { get; set; }
       public string language { get; set; }
    }
}
