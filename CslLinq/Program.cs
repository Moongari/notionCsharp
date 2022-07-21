using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
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
        private const string URL_RadarInfration = "https://www.data.gouv.fr/fr/datasets/r/1beaa1a9-1356-4884-afd9-aee8c4338a35";

        private static string[] entete;
        private static string[] arrayData;
        private static List<string> enteList = new List<string>();
        private static List<string> data = new List<string>();
        private static  int compteur = 0;
        private static string chaine = String.Empty;
        private static StringBuilder sb = new StringBuilder();
        
        private static int tailleEntete = 5;
        private static int maxColumn = 5;
        private static string[] tabChaine = new string[tailleEntete];
        private static string path = "out";
        private static string fileName = "RadarInfraction.csv";


        static async Task Main(string[] args)
        {
            startSynchronousMessage();
            //var MultiTask = MultipleTasksAsync();

            //MultiTask.Wait();
          
            await GetUrlAsyncRadarInfraction();

            await writeAndSaveDataInFile();
            //await getNombreOfData();
            endSynchronousMessage();
            // showData();
            Console.ReadLine();
        }
        public static void startSynchronousMessage()
        {
            Console.WriteLine("Starting program......");
        }

        public static void endSynchronousMessage()
        {
            Console.WriteLine("\r\n Data loading completed !");
        }

        static void showData()
        {
            var dataShow = from d in data select d;

            foreach (var item in dataShow)
            {
                Console.WriteLine($"{item}");
            }
        }

        static async Task MultipleTasksAsync()
        {
            Console.WriteLine("le programme peut realiser d'autres taches en parallele");
                
                //await GetURLAsync();
                await GetUrlAsyncRadarInfraction();
             
        }
        /// <summary>
        /// Recuperer les données via l'url et decoupe les données afin de generer un nouveau fichier
        /// </summary>
        /// <returns></returns>
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
                            Task.Delay(5).Wait();
                            sb.AppendJoin(",", tabChaine);

                            //Console.WriteLine(sb);

                            data.Add(sb.ToString());
                            Array.Clear(tabChaine, 0, tabChaine.Length);
                            compteur = 0; 
                            sb.Clear();
                            await getNombreOfData();

                        }
                    }
                 
                }

               

            }

            foreach (var item in data)
            {
                Console.WriteLine($"{item}\n");
            }
        }
       
        /// <summary>
        /// Indique le nombre de ligne inserer dans la liste ainsi que la progression des données
        /// </summary>
        /// <returns></returns>
        static async Task getNombreOfData()
        {
            var numbeOFLine = data.Count();
            int iValeur = arrayData.Length;
            double pourcentage = (numbeOFLine * 100) ;
            pourcentage = pourcentage / iValeur;
            await Task.Run(() => 
            {
               Console.WriteLine($"{pourcentage.ToString("0.00")} %");


            });

          


        }

        /// <summary>
        /// Recupere les données sources depuis l'url opendata
        /// </summary>
        /// <returns></returns>
        static async Task GetUrlAsyncRadarInfraction()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Waiting for GetURLAsync to happen");
                string output = await httpClient.GetStringAsync(URL_RadarInfration);
                entete = new string[tailleEntete];
                
                entete = output.Split(',');
                arrayData = (string[])entete.Clone();

               
                    

                   
                        Task.Delay(100).Wait();
                        arrayData = output.Split('\n');


                for (int j = 0; j < arrayData.Length; j++)
                {
                    if (j == 0)
                    {

                        var cloneArrayData = arrayData[j].Split(',');

                      
                        sb.AppendJoin(",", cloneArrayData);
                        addEntete(sb, true);


                    }
                    else
                    {
                        var cloneArrayData = arrayData[j].Split(',');

                   
                        sb.AppendJoin(",", cloneArrayData);
                        addDataInfraction(sb, false);
                    }

                    await getNombreOfData();
                }
                        


            }
        }

        /// <summary>
        /// ajout la lignes des entetes
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="isMaxEntete"></param>
        static void addEntete(StringBuilder sb, [Optional] bool isMaxEntete)
        {
            if(isMaxEntete == true)
            {
                data.Add(sb.ToString());
            }
           
            var info = from d in data
                       select d;

            Console.WriteLine("---------AFFICHAGE DES ENTETES DU FICHIER------");

            foreach (var item in info)
            {
                Console.WriteLine($"{item.ToUpper()}");
            }
                
            Console.WriteLine("------------------------------------------------");
            sb.Clear();
        }


        /// <summary>
        /// ajoute les données dans la collection data
        /// </summary>
        /// <param name="sb"></param>
        /// <param name="isMaxEntete"></param>
        static void addDataInfraction(StringBuilder sb, [Optional] bool isMaxEntete)
        {
            if (isMaxEntete != true)
            {
                data.Add(sb.ToString());
            }
            sb.Clear();

        }


        /// <summary>
        /// Sauvegarde du fichier dans le dossier out
        /// </summary>
        static void  saveDataInFile()
        {
            var pathAndFileName = Path.Combine(path, fileName);

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
                Console.WriteLine("Create directory : " + path);
                if (!File.Exists(pathAndFileName))
                {
                    Console.WriteLine($"Create file :  {fileName} ");
                    Console.WriteLine("Writing the file in progress.");
                    using (var fileStream = File.CreateText(pathAndFileName))
                    {
                        var infoData = from d in data select d;
                        foreach (var item in infoData)
                        {
                            fileStream.WriteLine(item.ToString());
                             pendingWriteFile().Wait();
                        }
                       
                    }

                }
            }
            else
            {
                if (File.Exists(pathAndFileName))
                {
                    Console.WriteLine($"delete file :  {fileName} ");
                    Console.WriteLine("Writing the file in progress.");
                    using (var fileStream = File.CreateText(pathAndFileName))
                    {
                        var infoData = from d in data select d;
                        foreach (var item in infoData)
                        {
                            fileStream.WriteLine(item.ToString());
                            pendingWriteFile().Wait();
                        }

                    }

                }


            }
           

          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        static async Task writeAndSaveDataInFile()
        {
            await Task.Run(() =>saveDataInFile());
           
        }

        static async Task pendingWriteFile()
        {
            Task.Delay(20).Wait();
            await Task.Run(()=>Console.Write("."));
        }

    }
}



