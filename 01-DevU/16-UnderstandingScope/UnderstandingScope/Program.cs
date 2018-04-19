using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingScope
{
    class Program
    {
        // private/public are accessability modifiers
        // Public = anyone can access
        // Private = only the class can access
        private static string k = "";

        static void Main(string[] args)
        {
            string j = "";

            for (int i = 0; i < 10; i++)
            {
                j = i.ToString();
                k = i.ToString();
                Console.WriteLine(i);

                if (i == 9)
                {
                    string l = i.ToString();
                }
                // Console.WriteLine(l);

            }

            // Console.WriteLine(i);
            Console.WriteLine("Outside the for: " + j);
            Console.WriteLine("Outside the for: " + k);

            HelperMethod();

            ////////////////////////////////////////////////////////

            Car myCar = new Car();
            // you should not see helperMethod() in the intellisense popup
            myCar.DoSomething();

            ////////////////////////////////////////////////////////

            Console.ReadLine();
        }

        static void HelperMethod()
        {
            Console.WriteLine("Value k from HelperMethod: " + k);
        }
    }

    class Car
    {
        public void DoSomething()
        {
            Console.WriteLine(helperMethod());
        }
        private string helperMethod()
        {
            return "Hello World!";
        }
    }
}
