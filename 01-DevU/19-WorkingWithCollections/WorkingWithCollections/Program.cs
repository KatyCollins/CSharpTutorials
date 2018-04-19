using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Car car1 = new Car();
            car1.Make = "Oldsmobile";
            car1.Model = "Cutlas Supreme";
            car1.VIN = "A1";

            Car car2 = new Car();
            car2.Make = "Geo";
            car2.Model = "Prism";
            car2.VIN = "B2";

            Book b1 = new Book();
            b1.Author = "Robert Tabor";
            b1.Title = "Microsoft .NET XML Web Services";
            b1.ISBN = "0-000-00000-0";
            */
            /////////////////////////////////////////////////////////////
            /*
            // Array List are dynamically sized
            // cool features - sorting, remove items
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(car1);
            myArrayList.Add(car2);

            // NOTE: these are not strongly typed
            // means that you can add a book incorrectly like this:
            myArrayList.Add(b1);

            // if you remove the item before it gets to display, it will still work fine
            myArrayList.Remove(b1);

            // That will cause this to throw exception when it gets to book
            foreach (Car car in myArrayList)
            {
                Console.WriteLine(car.Make);
            }
            */
            /////////////////////////////////////////////////////////////
            /*
            // list<T> - this is a generic list
            // same as above, but you have to specify a type
            // this is probably the most popular type

            List<Car> myList = new List<Car>();
            myList.Add(car1);
            myList.Add(car2);

            // this will now be flagged as an error while coding
            // myList.Add(b1);

            // that will ensure that this should run without issues
            foreach (Car car in myList)
            {
                Console.WriteLine(car.Model);
            }
            */
            /////////////////////////////////////////////////////////////
            /*
            // this is an example of a dictionary
            // it has a key that we can look up, 
            // then there is a definition next to it
            // Dictionary<TKey, TValue>

            Dictionary<string, Car> myDictionary = new Dictionary<string, Car>();
            myDictionary.Add(car1.VIN, car1);
            myDictionary.Add(car2.VIN, car2);

            Console.WriteLine(myDictionary["A1"].Make);
            Console.WriteLine(myDictionary["B2"].Make);
            */
            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////

            // all of the above need the definitions for cars and book above

            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////
            /////////////////////////////////////////////////////////////

            // string[] names = { "Bob", "Steve", "Brian", "Chuck" };

            // Object Initializer
            // No need for a constructor
            // Car car1 = new Car() { Make = "BMW", Model = "750li", VIN = "C3" };
            // Car car2 = new Car() { Make = "Toyota", Model = "4Runner", VIN = "D4" };

            // Collection Initializer
            List<Car> myList = new List<Car>() {
                new Car { Make = "Oldsmobile", Model = "Cutless Supreme", VIN = "E5" },
                new Car { Make = "Nissan", Model = "Altima", VIN = "F6" }
            };

            /////////////////////////////////////////////////////////////

            Console.ReadLine();
        }
    }

    class Car
    {
        public string VIN { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }

    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
    }


}
