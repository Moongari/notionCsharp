using System;
using System.Collections.Generic;
using System.Linq;

namespace CslLinq
{
    internal class Program
    {

        public delegate void delSuperieur(Personne p);
        public delegate void delquestionUser(string message);

        static void Main(string[] args)
        {


            IList<Personne> personnlist = new List<Personne>();

            personnlist.Add(new Personne("Robert", 13, "Oxford", "England"));
            personnlist.Add(new Personne("Selma", 19, "Dole", "France"));
            personnlist.Add(new Personne("Albert", 34, "Oxford", "England"));
            personnlist.Add(new Personne("Wassila", 25, "Paris", "France"));
            personnlist.Add(new Personne("Brahim", 36, "Dammarie les lys", "France"));
            personnlist.Add(new Personne("Ismail", 9, "Dubai", "Dubai"));
            personnlist.Add(new Personne("Francoise", 78, "Bouzole", "France"));
            personnlist.Add(new Personne("Mohamed", 45, "Damparis", "France"));

            Personne p1 = new Personne("Robert", 23, "Oxford", "England");
            Personne p2 = new Personne("Robert", 24, "Oxford", "England");

            Console.WriteLine("------------Result class ----------");
            // comparaison par référence
            if (p1.Equals(p2))
                {
                Console.WriteLine(p1.Equals(p2));
            }
            else
            {
                Console.WriteLine(p1.Equals(p2));
            }

            // comparaison de 2 valeur avec une struct

            PersonneStruct ps1 = new PersonneStruct();
            PersonneStruct ps2 = new PersonneStruct();

            ps1.name = "ALbert"; ps1.age = 34;
            ps2.name = "ALbert"; ps2.age = 23;

            // comparaison par valeur
            Console.WriteLine("------------Result Struct ----------");
            Console.WriteLine(ps1.Equals(ps2));

        }



        public struct PersonneStruct
        {
            public  string name { get; set; }
            public  int age { get; set; }



            public void affiche()
            {
                Console.WriteLine($" Name : {name}  Age : {age} ans");
            }
        }


    }
}
