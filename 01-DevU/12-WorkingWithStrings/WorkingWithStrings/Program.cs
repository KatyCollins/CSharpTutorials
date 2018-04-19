using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            // string myString = "My \"so-called\" life";
            // string myString = "What if I need a\nnew line?";
            // string myString = "Go to your c:\\ drive";

            // The @ means to translate this as a literal string
            // string myString = @"Go to your c:\ drive";

            // the {} are called replacement codes
            // they can be done in any order and repeated
            // string myString = String.Format("{1} = {0}", "First", "Second");

            // the 0:C means that you want to 
            // format the first item into currency format
            // string myString = string.Format("{0:C}", 123.45);


            // 0:N formats the number with decmials and commas
            // string myString = string.Format("{0:N}", 1234567890);

            // string myString = string.Format("Percentage: {0:P}", .123);


            // Custom Format (this can cause issues if it does not have 
            // enough #s to match your output
            // It piles the extra numbers onto the first set of numbers
            // just something to be aware of
            //string myString = string.Format(
            //    "Phone Number: {0:(###) ###-####}", 123456789012);


            /////////////////////////////////////////////////////////////


            // string myString = " Long ago, before we met, I dreamed about you  ";

            // This grabs all chars afer the 6th, up to 14
            // myString = myString.Substring(6, 14);

            // Converts to CAPS
            // myString = myString.ToUpper();

            // replace spaces with dashes
            // myString = myString.Replace(" ", "--");

            // Remove a substring of chars
            // Starts at 6
            // removes 14 chars
            // myString = myString.Remove(6, 14);

            // remove starting and ending spaces
            // myString = String.Format("Length Before: {0} -- Length After: {1}",
            //    myString.Length, myString.Trim().Length);


            /////////////////////////////////////////////////////////////


            /*
            // This is a bad way to do this
            // rebuilds the string 100 times for each add
            // its like an array expansion
            string myString = "";

            for (int i = 0; i < 100; i++)
            {
                myString += "--" + i.ToString();
            }
            */

            // This is a more efficiant way to do it:
            StringBuilder myString = new StringBuilder();
            for (int i = 0; i < 100; i++)
            {
                myString.Append("--");
                myString.Append(i);
            }


            Console.WriteLine(myString);
            Console.ReadLine();
        }
    }
}
