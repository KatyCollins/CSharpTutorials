using System;
using System.Net;

namespace AssemliesAndNamespaces
{
    class Program
    {
        static void Main(string[] args)
        {
            // this the "full name" or namespace

            // usually dont have to include it because 
            // you have specified it with "using" above

            System.Console.WriteLine("Hello World!");

            //////////////////////////////////////////////////////////////////////
            /*
            // to find librarires, use this for google/bing
            // site:microsoft.com write to text file using C#
            // gives you a few examples in this URL:
            // https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/file-system/how-to-write-to-a-text-file

            // Example #2: Write one string to a text file.
            string text = "A class is the most powerful data type in C#. Like a structure, " +
                           "a class defines the data and behavior of the data type. ";
            // WriteAllText creates a file, writes the specified string to the file,
            // and then closes the file.    You do NOT need to call Flush() or Close().
            System.IO.File.WriteAllText(@"C:\Lesson17\WriteText.txt", text);

            // NOTE:  you could also remove the system.io from here 
            // by adding a "using" clause above

            // NOTE: you need to make sure the directory above 
            // is created or it will throw an exeption.
            */
            //////////////////////////////////////////////////////////////////////
            /*
            // Another example of the above
            string text = "We want to write this to our file";

            System.IO.File.WriteAllText(@"C:\Lesson17\WriteText.txt", text);
            */
            //////////////////////////////////////////////////////////////////////

            // another google search using:
            // site:microsoft.com c# download html as string

            // this is a different site, there is one that has the whole library in it
            // but this will work for our purposes, url:
            // https://msdn.microsoft.com/en-us/library/fhd1f0sw(v=vs.110).aspx

            // webClient is not recognized because it is not the full namespace(assembly)
            // you can fix this with the lightbulb by adding the "using" clause
            // also, the lightbulb should give you an option to add the full namespace here
            WebClient client = new WebClient();
            string reply = client.DownloadString("http://msdn.microsoft.com");

            Console.WriteLine(reply);
            System.IO.File.WriteAllText(@"C:\Lesson17\WriteText.txt", reply);

            //////////////////////////////////////////////////////////////////////

            Console.ReadLine();
        }
    }
}
