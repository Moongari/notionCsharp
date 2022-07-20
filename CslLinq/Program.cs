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
        private static List<string> enteList = new List<string>();
        private static List<string> data = new List<string>();
        private static  int compteur = 0;
        private static string chaine = String.Empty;
        private static StringBuilder sb = new StringBuilder();
        
        private static int tailleEntete = 5;
        private static int maxColumn = 4;
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
            Console.WriteLine("Chargement des données Terminé.....");
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
            int iValeur = entete.Length/4;
            double pourcentage = (numbeOFLine * 100) ;
            pourcentage = pourcentage / iValeur;
            await Task.Run(() => 
            {
               Console.WriteLine($"number of line insert : {numbeOFLine} => progression : {pourcentage.ToString("0")} %");


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
              

                for (int i = 0; i < entete.Length; i++)
                {
                    if (i == 0)
                    {
                        entete = output.Split('\n');

                        tabChaine[i] = entete[i];
                        if (i == 0)
                        {
                            
                            sb.AppendJoin(",", tabChaine);
                            addEntete(sb, true);
                            Array.Clear(tabChaine, 0, tabChaine.Length);
                            
                        }

                    }
                    else
                    {
                        Task.Delay(10).Wait();

                        entete = entete[i].Split(',');

                        for (int j = 0; j < entete.Length; j++)
                        {
                            if (compteur < maxColumn)
                            {
                                tabChaine[compteur] = entete[j];

                            }
                        }

                       

                        if (compteur == maxColumn-1)
                        {
                            sb.AppendJoin(",", tabChaine);
                            addDataInfraction(sb, false);
                            Array.Clear(tabChaine, 0, tabChaine.Length);
                            compteur = 0;
                            await getNombreOfData();
                        }
                    
                        compteur++;
                    }

                    
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
                Console.WriteLine("creation du répertoire");
                if (!File.Exists(pathAndFileName))
                {
                    Console.WriteLine($"Création du fichier  {fileName} ");

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
                    Console.WriteLine($"on écrase le fichier :  {fileName} ");

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
            await Task.Run(()=>Console.WriteLine("Ecriture du fichier en cours.."));
        }

    }
}



