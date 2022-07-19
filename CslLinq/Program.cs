using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CslLinq
{
    internal class Program
    {
        private static bool isOk =false;

        public delegate void delSuperieur(Personne p);
        public delegate void delquestionUser(string message);
        static Random rnd = new Random();

        static async Task Main(string[] args)
        {
       
            var affiche = compteur();
            
            Console.WriteLine("Demarrage des operations...");
            await operation();

            Console.WriteLine("Fin du programme");
        }



        static async Task compteur()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
           
        }


        static async Task operation()
        {
            
            int result = 0;
            
            for (int i = 0; i < 10; i++)
            {
                var valeur = rnd.Next(10, 100);
                await Task.Delay(1000);
                result = valeur + valeur;
                Console.Write(result);
            }

            
        }
    }
}
