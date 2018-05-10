using System;
using System.Collections.Generic;
using System.Linq;
// using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            // need to add system.speech reference to project for this to work.
            // SpeechSynthesizer synth = new SpeechSynthesizer();
            // synth.Speak("Hello! This is the gradebook program");

            GradeBook book = new GradeBook();

            ///////////////////////////////////////////////////////////////

            // need to initialize the delegate
            // why not just do this in constructor?
            // because you need the name of the method to be called.
            book.NameChanged += new NameChangedDelegate(OnNameChanged);

            /*
            // this will overwrite the original, wont trigger both methods
            book.NameChanged = new NameChangedDelegate(OnNameChanged2);

            // must do the += for it to do both
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            // as an event, you can add the same method twice
            book.NameChanged += new NameChangedDelegate(OnNameChanged2);

            // as an event, you can also reduce some of the code
            // The C# compiler is smart enough to know what this means
            book.NameChanged += OnNameChanged2;

            // you can also do this to remove a reference:
            // this only removes one of them, 
            // you would have to remove all 3 in this example to stop it
            book.NameChanged -= new NameChangedDelegate(OnNameChanged2);
            */

            ///////////////////////////////////////////////////////////////

            book.Name = "Katy's Grade Book";
            book.Name = "Grade Book";
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            //cw <tab><tab> creates a writeline
            // Console.WriteLine(stats.AverageGrade);
            // Console.WriteLine(stats.HighestGrade);
            // Console.WriteLine(stats.LowestGrade);

            // this shows how method overloading is used
            Console.WriteLine(book.Name);
            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", (int)stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            // WriteResult("example of multi-parms", 1, 2, 3, 4);

            ///////////////////////////////////////////////////////////////

            /*
            // this logic shows how pointers/references work for classes
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook(); // if this was not here, g2 would show g1's name
            g1.Name = "Katy's grade book";
            Console.WriteLine(g2.Name);
            */

            Console.ReadLine();
        }

        ///////////////////////////////////////////////////////////////
                    // this section is events vs delegates
        ///////////////////////////////////////////////////////////////

        // this is the method that will be called with NameChangedDelegate
        // variable names dont have to match but the type signature does
        /*
        static void OnNameChanged(string existingName, string newName)
        {
            Console.WriteLine($"Gradebook changing name from {existingName} to {newName}");
        }

        static void OnNameChanged2(string existingName, string newName)
        {
            Console.WriteLine("***");
        }
        */

        // new logic to support the new standard format
        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Gradebook changing name from {args.ExistingName} to {args.NewName}");
        }

        ///////////////////////////////////////////////////////////////
                    // this section is method overloading
        ///////////////////////////////////////////////////////////////

        // method overloading
        //static void WriteResult(string description, params float[] result)
        // if you were to set this as params, would need to loop through array
        static void WriteResult(string description, float result)
        {
            // the 1:F2 says to format the second parm to floating 2 decimals
            // more formatting like this can be found online
            Console.WriteLine("{0}: {1:F2}", description, result);

            // the 0 and 1 can be set directly to the variable like so:
            // Console.WriteLine($"{description}: {result:F2}", description, result);
        }

        static void WriteResult(string description, int result)
        {
            Console.WriteLine(description + ": " + result);
        }

    }
}
