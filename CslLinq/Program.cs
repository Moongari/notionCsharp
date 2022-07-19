using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CslLinq
{
    internal class Program
    {
        private static bool isOk =false;

        public delegate void delSuperieur(Personne p);
        public delegate void delquestionUser(string message);

        static void Main(string[] args)
        {

            // fonction synchrone

            var webClient = new WebClient();
            Console.WriteLine("Telechargement.....");
            string url = "https://sm.mashable.com/mashable_in/seo/2/24308/24308_tz9f.jpg";
            //webClient.DownloadFile(url, "pierre.jpg");
        

            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
            webClient.DownloadFileAsync(new Uri(url), "24308_tz9f.jpg");

            while (true)
            {
                if (isOk) { break; }
            }

            Console.WriteLine("Fin du programme");
        }

        private static void WebClient_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            
            Console.WriteLine("Telechargement terminé");
            isOk = true;

        }
    }
}
