using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectLifetime
{
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car();

            /* 
            myCar.Make = "Oldsmobile";
            myCar.Model = "Cutlass Supreme";
            myCar.Year = 1986;
            myCar.Color = "Silver";

            /////////////////////////////////////////////////////

            Car myOtherCar;
            myOtherCar = myCar;

            Console.WriteLine("{0} {1} {2} {3}",
                myOtherCar.Make, myOtherCar.Model, 
                myOtherCar.Year.ToString(), myOtherCar.Color);

            /////////////////////////////////////////////////////

            // the 98 changes the original because it is a pointer
            myOtherCar.Model = "98";

            Console.WriteLine("{0} {1} {2} {3}",
                myOtherCar.Make, myOtherCar.Model,
                myOtherCar.Year.ToString(), myOtherCar.Color);

            Console.WriteLine("{0} {1} {2} {3}",
                myCar.Make, myCar.Model, myCar.Year.ToString(), myCar.Color);

            /////////////////////////////////////////////////////

            // This removes the pointer

            myOtherCar = null;

            // if you tried to print this again, it would cause exception

            /////////////////////////////////////////////////////

            // removes remaining reference to data
            // eventually garbage collector will pick this up

            // you can also tell .NET to do it now
            // this is called deterministic finalization

            myCar = null;

            */
            /////////////////////////////////////////////////////

            // this display is to show that the constructor is working.
            // the code above this was mostly commented out

            Console.WriteLine("{0} {1} {2} {3}",
                myCar.Make, myCar.Model, myCar.Year.ToString(), myCar.Color);

            /////////////////////////////////////////////////////

            Car myThirdCar = new Car("Ford", "Escape", 2005, "White");

            Console.WriteLine("{0} {1} {2} {3}",
                myThirdCar.Make, myThirdCar.Model, 
                myThirdCar.Year.ToString(), myThirdCar.Color);

            /////////////////////////////////////////////////////

            Car.MyMethod();

            /////////////////////////////////////////////////////

            /////////////////////////////////////////////////////

            /////////////////////////////////////////////////////

            /////////////////////////////////////////////////////

            Console.ReadLine();

        }
    }

    class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }

        // Constructor
        public Car()
        {
            // the "this" is optional
            this.Make = "Nissan";

            // can use this for automatically putting class into valid state
            // could also be fed from file or DB
        }

        // overloaded constructor
        public Car(string make, string model, int year, string color)
        {
            // C# sees the difference in CAPS
            // That is why this can work
            // uppercase = variable
            // lowercase = parms
            Make = make;
            Model = model;
            Year = year;
            Color = color;
        }

        // when you use "static" you don't have to declair them as objects
        public static void MyMethod()
        {
            Console.WriteLine("Called the static MyMethod");

            // Note, you cannot use values in the class when you do this
            // IE - you cant use instance variables that require a specific item
            
            // they have to be declaired as static as well

            // these static values are things that remain the 
            // same across all calls for the instances
        }

    }
    }
