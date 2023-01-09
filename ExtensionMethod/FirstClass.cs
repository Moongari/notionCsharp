using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public class FirstClass
    {
        public  int solde { get; set; }
        private  readonly int salary = 1200;

        public void Test1()
        {
            Console.WriteLine("Method One" + this.solde) ;

        }

        public void Test2()
        {
            Console.WriteLine("Method Two" + this.solde);

        }


        public int getSolde() { return this.solde; }

        public  int getSalary()
        {
            return salary;
        }

    }
}
