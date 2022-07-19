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

            Personne p = new Personne("Robert", 23, "Oxford", "England");

            //Delegate Action....
            Action<Personne> delSuperieurAction = p.isBiggerOfPersonne;

           // declaration du delegate
            delSuperieur delSuperieur = new delSuperieur(p.isBiggerOfPersonne);
            // on recupere la liste des personnes dont l'age est superieur a 0
            var listPers =  personnlist.Where(p => p.age > 0).ToList();

            Console.WriteLine("-------------------------- Action ---------------------------------");
            foreach (Personne p1 in listPers)
            {
                //delSuperieur(p1);
                delSuperieurAction(p1);
            }

            Console.WriteLine("--------------------------delegate appel method---------------------------------");
            delquestionUser delquestionUser = questionUtilisateur;
            //delquestionUser("Veuillez indiquer votre nom ?");
            //delquestionUser = questionUtilisateurAge;
            //delquestionUser("Veuillez saisir votre age?");


            Console.WriteLine("--------------------------PREDICATE---------------------------------");
            Predicate<int> verifAge = s => s > 23;

                Random rnd = new Random();
                var valeur =  rnd.Next(10, 45);

            if (verifAge(valeur))
            {
                Console.WriteLine($"Valeur valid : {valeur}");
            }
            else
            {
                Console.WriteLine($"Valeur invalid : {valeur}");
            }
            Console.WriteLine("--------------------------Func---------------------------------");

            Func<int, int, int> calc = addition;

            Console.WriteLine($"Resultat de l'addition : {calc(valeur, valeur)}");

        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        static public void questionUtilisateur(string message)
        {

            Console.WriteLine(message);
            var result = Console.ReadLine();

            if (result != null)
            {
                Console.WriteLine($"votre nom est : {result}");
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        static public void questionUtilisateurAge(string message)
        {
            int age = 0;
            Console.WriteLine(message);
            var result = Console.ReadLine();

            bool isValidAge =  int.TryParse(result, out age);
            if (result != null )
            {
                if(age > 18)
                {
                    Console.WriteLine("Vous etes majeur ");
                    Console.WriteLine($"votre age est  : {age} ans");
                    Console.WriteLine("Autorisation valider ");
                }
                else
                {
                    Console.WriteLine("Vous etes mineur ,autorisation refuser ");
                }
               
            }

        }


        static public int addition(int val,int val2)
        {
            return val + val2;
        }





    }
}
