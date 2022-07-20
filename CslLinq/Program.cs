using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CslLinq
{
    internal class Program
    {
        private static bool isOk =false;

        public delegate void delSuperieur(Personne p);
        public delegate void delquestionUser(string message);
        static Random rnd = new Random();

        private const string URL = "https://www.data.gouv.fr/fr/datasets/r/8a22b5a8-4b65-41be-891a-7c0aead4ba51";
        private static string[] entete;
        private static List<string> enteList = new List<string>();
        private static List<string> data = new List<string>();
        private static  int compteur = 0;
        private static string chaine = String.Empty;
        private static StringBuilder sb = new StringBuilder();
        private static string[] tabChaine = new string[15];

        static async Task Main(string[] args)
        {
            startSynchronousMessage();
            //var MultiTask = MultipleTasksAsync();

            //MultiTask.Wait();
          
            await GetURLAsync();


            Console.ReadLine();
        }
        public static void startSynchronousMessage()
        {
            Console.WriteLine("Starting program......");
        }

        static async Task MultipleTasksAsync()
        {
            Console.WriteLine("le programme peut realiser d'autres taches en parallele");
                
                await GetURLAsync();
                getNombreOfData().Wait();
        }

        static async Task GetURLAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Waiting for GetURLAsync to happen");
                string output = await httpClient.GetStringAsync(URL);
                entete = new string[15];

                 entete = output.Split(',');
              

                for (int i = 0; i < entete.Length; i++)
                {
                    if (i <= 14)
                    {
                        enteList.Add(entete[i]);
                    }
                    else
                    {
                        if (compteur < 14)
                        {
                            //chaine = String.Join(',', entete[i]);
                           
                            tabChaine[compteur]= entete[i];

                              

                              }
                       
                        compteur++;
                        if(compteur == 15)
                        {
                            Task.Delay(500).Wait();
                            sb.AppendJoin(".", tabChaine);
                            Console.WriteLine(sb);
                            data.Add(sb.ToString());
                            Array.Clear(tabChaine, 0, tabChaine.Length);
                            compteur = 0; 
                            sb.Clear();
                            await getNombreOfData();
                        }
                    }
                 
                }
               
                Console.WriteLine(output);


            }
        }
       

        static async Task getNombreOfData()
        {
            var numbeOFLine = data.Count();
            int iValeur = entete.Length;
            double pourcentage = (numbeOFLine * 100) ;
            pourcentage = pourcentage / iValeur;
            await Task.Run(() => 
            {
                Console.WriteLine($"number of line insert : {numbeOFLine} => progression : {pourcentage.ToString("N")} %");


            });

          


        }
    }
}
