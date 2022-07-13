using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CslLinq
{
    public class Personne
    {
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


    }
}
