using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CslLinq
{
    internal class Program
    {
        private static bool isOk =false;

        public delegate void delSuperieur(Personne p);
        public delegate void delquestionUser(string message);
        static Random rnd = new Random();

        private const string URL = "https://www.c-sharpcorner.com/";

        static void Main(string[] args)
        {
            DoingSynchronous();
            var MultiTask = MultipleTasksAsync();
            DoingSynchronousAfterAwait();
            MultiTask.Wait();
            Console.ReadLine();
        }
        public static void DoingSynchronous()
        {
            Console.WriteLine("Starting a program");
        }

        static async Task MultipleTasksAsync()
        {
            Console.WriteLine("Doing Multiple tasks at a time ");
            await GetURLAsync();
        }

        static async Task GetURLAsync()
        {
            using (var httpClient = new HttpClient())
            {
                Console.WriteLine("Waiting for GetURLAsync to happen");
                string output = await httpClient.GetStringAsync(URL);
                Console.WriteLine($"\n OK! awaiting has finished \n The length of {URL} is {output.Length} characters");
            }
        }
        static void DoingSynchronousAfterAwait()
        {
            Console.WriteLine("Mean While I'm doing some other work");
            for (var i = 0; i <= 10; i++)
            {
                Console.Write("I'm Updating the Weather Info \t");
            }

        }
    }
}
