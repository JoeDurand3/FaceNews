using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceNews;

namespace FaceNewsDebug
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = TextAnalyticsService.Instance.GetTextAnalyticsAsync("1", "test this sentence");
            Task.WaitAll(test);

            var testResult = test.Result;
            Console.Write(testResult.documents.Count);
           // byte[] byteData = Encoding.UTF8.GetBytes("");
        }
 
    }
}
