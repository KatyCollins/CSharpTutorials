using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HandlingExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // as a best practice, start with most specific exceptions first
            // then work you way up to more general ones
            // the more specific ones will be the ones excecuted first that way

            /* NOTE: you can find the exception names by doing a 
             * google search on the libraries that you are using.
             * Most of the Microsoft ones should be on MSDN.
             * We found the below by searching for "system.io.File.ReadAllText"
             * We seleced the function for the version of the overload we used
             * that brought us to this page that showed us the names:
             * https://msdn.microsoft.com/en-us/library/ms143368(v=vs.110).aspx
             * 
             */
            try
            {
                string content = File.ReadAllText(@"C:\Lesson22\Exampl.txt");
                Console.WriteLine(content);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("There was a problem:");
                Console.WriteLine("Make sure the name of the file is correct");
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("There was a problem:");
                Console.WriteLine("Make sure the name of the directory is correct");
            }
            catch (Exception ex)
            {
                Console.WriteLine("There was a problem:");
                Console.WriteLine(ex.Message);
            }
            finally
            {
                // Code to finalize
                // Setting objects to null
                // Closing DB connections
                // This will always run
                Console.WriteLine("I like to move it move it");
            }

            Console.ReadLine();
        }
    }
}
