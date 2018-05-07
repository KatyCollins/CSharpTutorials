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
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);

            GradeStatistics stats = book.ComputeStatistics();

            //cw <tab><tab> creates a writeline
            Console.WriteLine(stats.AverageGrade);
            Console.WriteLine(stats.HighestGrade);
            Console.WriteLine(stats.LowestGrade);

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
    }
}
