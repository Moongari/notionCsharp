using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class ThirdClass
    {


        public static void ShowSalary(this FirstClass firstClass)
        {
            Console.WriteLine("show salary "+ firstClass.getSalary());
        }



    }
}
