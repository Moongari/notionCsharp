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
            Console.WriteLine("Method Three");
        }

        public static void Test4(this FirstClass O,int x)
        {
            Console.WriteLine("Method Four" + x);
        }

        public static void Test5(this FirstClass O)
        {
            Console.WriteLine("Method Five"+ O.x);
        }

    }
}
