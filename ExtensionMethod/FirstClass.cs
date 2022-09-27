using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public class FirstClass
    {
        public int x = 100;

        public void Test1()
        {
            Console.WriteLine("Method One" + this.x);

        }

        public void Test2()
        {
            Console.WriteLine("Method Two" + this.x);

        }



    }
}
