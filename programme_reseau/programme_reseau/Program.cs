using System;
using System.Net;

namespace programme_reseau
{
    class Program
    {
        static void Main(string[] args)
        {

            string url = "https://codeavecjonathan.com/res/papillon.jpg";
            var webClient = new WebClient();

            try
            {
                webClient.DownloadFile(url,"papillon.jpg");
                Console.WriteLine("telechargement terminé");

            }
            catch (WebException ex)
            {

                if (ex.Response != null)
                {

                    var statusCode = ((HttpWebResponse)ex.Response).StatusCode;

                    if (statusCode == HttpStatusCode.NotFound)
                    {
                        Console.WriteLine("Erreur reseau : non trouvé");
                    }
                    else
                    {
                        Console.WriteLine("ERROR :" + statusCode);
                    }
                }
                else
                {
                    Console.WriteLine("Error : " + ex.Message);
                }

            }


        }

    }
}
