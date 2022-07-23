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

            Console.WriteLine("------------Result Record ----------");
            var personne1 = new PersonneRecord("Tata", 45);
            // avec le mot clé with on peut cloner l'objet Personne1 et lui donner de nouvelles valeurs
            var personne2 = personne1 with {};


            // utilisation du deconstructeur

            var (name, age) = personne1;

            personne1.affiche();
            personne2.affiche();

        
            Console.WriteLine("nom : "+ name);
            Console.WriteLine("nom : " + age);

            var personnage1 = new AffichePersonnage(34, "Guerrier");
            var personnage2 = new AffichePersonnage(40, "Magicien");
            var personnage3 = new AffichePersonnage(58, "Chevalier");
            var personnage4 = new AffichePersonnage(23, "Fantassin");

            personnage1.MostStronger(personnage1, personnage2);
            personnage2.MostStronger(personnage1, personnage3);
            personnage3.MostStronger(personnage1, personnage4);

                

        }

        //utilisation simplifier d'un record les données sont immutables
        record personnage(int force, string role);
        /// <summary>
        /// Heritage dans les records
        /// </summary>
        record AffichePersonnage: personnage
        {
            public AffichePersonnage(int force,string role) : base(force,role)
            {
               
            }

            public void Description()
            {
                Console.WriteLine($" FORCE = {force} , Role = {role}");
            }

            public void MostStronger(AffichePersonnage p1, AffichePersonnage p2)
            {
                if(p1.force > p2.force)
                {
                    Console.WriteLine($"{p1.role} est plus fort que {p2.role}");
                }
                else
                {
                    Console.WriteLine($"{p2.role} est plus fort que {p1.role}");
                }
            }
        }

        /// <summary>
        /// Struct
        /// </summary>
        public struct PersonneStruct
        {
            public  string name { get; set; }
            public  int age { get; set; }



            public void affiche()
            {
                Console.WriteLine($" Name : {name}  Age : {age} ans");
            }
        }

        // les records permettent d'avoir la souplesse d'une struct et la puissance d'une classe
        

        /// <summary>
        /// Record passage par reference comme une classe
        /// </summary>
        record PersonneRecord
        {
            public string name { get; init; }
            public int age { get; init; }

            /// <summary>
            /// constructeur de l'objet Record
            /// </summary>
            /// <param name="nom"></param>
            /// <param name="age"></param>
            public PersonneRecord(string nom, int age)
            {
                this.name = nom;
                this.age = age;
            }

            //Deconstructeur de l'objet Record
            public void Deconstruct(out string nom, out int age)
            {
                nom =this.name;
                age =this.age;
            }


            public void affiche()
            {
                Console.WriteLine($" Name : {name}  Age : {age} ans");
            }

          
        }
    }
}
