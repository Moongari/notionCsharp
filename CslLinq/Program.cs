using System;
using System.Collections.Generic;
using System.Linq;

namespace CslLinq
{
    internal class Program
    {

        public delegate void delSuperieur(Personne p);
    
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

            foreach (Personne p1 in listPers)
            {
                //delSuperieur(p1);
                delSuperieurAction(p1);
            }
          


        }

    }
}
