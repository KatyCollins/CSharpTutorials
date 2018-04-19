using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The Name Game");


            Console.Write("What's your first name? ");
            string firstName = Console.ReadLine();

            Console.Write("What's your last name? ");
            string lastName = Console.ReadLine();

            Console.Write("In what city were you born?");
            string city = Console.ReadLine();


            DisplayResult(
                ReverseString(firstName),
                ReverseString(lastName),
                ReverseString(city));

            DisplayResult(
                ReverseString(firstName) + " " +
                ReverseString(lastName) + " " +
                ReverseString(city));


            Console.ReadLine();

        }


        /*
            His advice is that no method should have more than 6 
            lines of code, if it does, it is trying to do too much.

            Each method should only do 1 thing
            if it is doing more than that, break it up
        */
        private static string ReverseString(string message)
        {
            char[] messageArray = message.ToCharArray();
            Array.Reverse(messageArray);
            return String.Concat(messageArray);
        }

        private static void DisplayResult(
            string fname, 
            string lname, 
            string city)
        {
            Console.Write(String.Format("{0} {1} {2}",
                fname,
                lname,
                city));
        }

        private static void DisplayResult(string message)
        {
            Console.Write(message);
        }

    }
}
