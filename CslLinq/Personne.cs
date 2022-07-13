﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslLinq
{
    public class Personne
    {

        private readonly int maxAge = 23;
        public string name { get; set; }
        public int age { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public Personne(string name, int age, string city, string country)
        {
            this.name = name;
            this.age = age;
            this.city = city;
            this.country = country;
        }

      

        public void afficher()
        {
            Console.WriteLine($" name : {name}  age :{age}  city : {city}  country : {country}");
        }


        public string message(Personne p)
        {
            return p.name;
        }

        public void controleAge(Personne p)
        {
            if (p.age > maxAge)
            {
                Console.WriteLine("Autorisation validée.");
            }

            Console.WriteLine("Autorisation refusée");
        }


        public Personne comparePersonne(Personne p1, Personne p2) { 
        
        
           if(p1.age > p2.age)
            {
                return p1;
            }

            if (p1.age.Equals(p2.age))
            {
                return p2;
            }

              return p2;
        }


    }
}
