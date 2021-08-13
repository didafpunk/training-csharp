using System;
using System.Net;
using System.Threading;

namespace AsyncDelegate
{
    class Program
    {

        static bool donwloading = true;

        static void Main(string[] args)
        {



            string filename = "bateau.jpg";
            string url = "https://codeavecjonathan.com/res/bateau.jpg";
            var webClient = new WebClient();

            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            Console.Write("Downloading.");
            webClient.DownloadFileAsync(new Uri(url), filename);


            while (donwloading)
            {

                Thread.Sleep(500);
                if (donwloading)

                {
                    Console.Write(".");
                }
            }




        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Downloading finished");
            donwloading = false;
        }
    }
}
