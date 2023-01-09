using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class SecondClass
    {

        

        public static void Test3(this FirstClass O)
        {
            var solde = O.getSolde();
            Console.WriteLine("Method Three get solde by First Class" + solde);
        }

        public static void Test4(this FirstClass O,int x)
        {
            Console.WriteLine("Method Four" + x);
        }

        public static void Test5(this FirstClass firstClass)
        {
            firstClass.solde= 300;
            Console.WriteLine("Method Five "+ firstClass.getSolde());
        }


        

    }
}
