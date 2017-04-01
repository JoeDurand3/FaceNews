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

            var test2 = NewsService.Instance.GetNewsAsync();
            Task.WaitAll(test2);
            var test2Result = test2.Result;
            Console.WriteLine(test2Result.value[0].name);

            var test = TextAnalyticsService.Instance.GetTextAnalyticsAsync("1", test2Result.value[0].name);
            Task.WaitAll(test);
            var testResult = test.Result;
            Console.WriteLine(testResult.documents[0].score);


        }

    }
}
