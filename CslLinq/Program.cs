using System;
using System.Collections.Generic;
using System.Linq;

namespace CslLinq
{
    internal class Program
    {
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



            var resultPersonn = from personn in personnlist
                                orderby personn.name ascending
                                select personn;

            // tri par nom
            foreach (var p in resultPersonn)
            {
                Console.WriteLine(p.name + " - " + p.age + " ans");
            }



            var resultPersonn2 = personnlist.OrderBy(personn => personn.age);

            Console.WriteLine("---------------------------------------------------");
            //tri par age croissant
            foreach (var item in resultPersonn2)
            {
                Console.WriteLine(item.name + " - " + item.age + " ans");
            }


            Console.WriteLine("---------------------------------------------------");

            // affiche les personnes qui habitent en Angleterre.
            var resultPersonn3 = personnlist.Where(personn => personn.country == "England");

            resultPersonn3.ToList().ForEach(personn => personn.afficher());

            Console.WriteLine("---------------------------------------------------");

            var resultPersonn4 = personnlist.Where(p => p.city.StartsWith("P") && p.age >10);


            resultPersonn4.ToList().ForEach(personn => personn.afficher());




            Console.WriteLine("---------------------------------------------------");

            // la fonction ToLookup permet de créer des groupes 
            //on peut ensuite repartir ces groupes en fonction d'un criteres bien definit ici la ville
            var result = personnlist.ToLookup(p => p.city);

            foreach (var category in result)
            {
                Console.WriteLine(string.Format(" City : {0}", category.Key));
                foreach (var item in category)
                {
                    Console.WriteLine(string.Format("\t Name :{0} | age : {1} ",item.name,item.age));
                }
            }
        }

    }
}
