using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FaceNews.Core;

namespace FaceNewsDebug
{
    class Program
    {
        static void Main(string[] args)
        {

            var test2 = NewsService.Instance.GetNewsAsync();
            Task.WaitAll(test2);
            var test2Result = test2.Result;
            var test3 = NewsService.Instance.GetNewsAsync("Health");
            Task.WaitAll(test3);
            var test3Result = test3.Result;
            try
            {
                Console.WriteLine(test2Result.value[0].name);
                Console.WriteLine(test3Result.value[0].name);
                //Console.WriteLine(test2Result.value[0].name);
            }
            catch(NullReferenceException e)
            {
                Console.WriteLine(e.Message); 
            }

            //var test = TextAnalyticsService.Instance.GetTextAnalyticsAsync("1", test2Result.value[0].name);
            //Task.WaitAll(test);
            //var testResult = test.Result;
            //Console.WriteLine(testResult.documents[0].score);


        }

    }
}
