using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsyncAwait
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string url1 = "http://codeavecjonathan.com/res/dummy.txt";
            string url2 = "http://codeavecjonathan.com/res/pizzas1.json";
            Console.Write("telechargement...");
            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            //  await downloadTask1;
            // await downloadTask2;
         await   Task.WhenAll(downloadTask1, downloadTask2);
            Console.WriteLine("fin du programme");
        }

        static async Task DownloadData(string url)
        {

            var httpClient = new HttpClient();
         


            var result = await httpClient.GetStringAsync(url);
           

            Console.WriteLine("ok =>"+url);

//            Console.WriteLine(result);



           

        }

        static async Task DisplayProgress()
        {

            while (true)
            {
              await  Task.Delay(500);

                Console.WriteLine(".");
            }
        }
     }
}
