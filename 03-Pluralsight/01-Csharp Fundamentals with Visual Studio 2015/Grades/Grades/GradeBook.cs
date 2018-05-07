using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // if you dont specify this, it will be marked "internal"
    // that means you wont be able to run unit tests on this
    // public = everywhere
    // private = only in same class
    // internal = only in same assembly
    public class GradeBook
    {
        // ctor <tab><tab> creates blank constructor
        public GradeBook()
        {
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach(float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public string Name;

        // if public is not defined, it is assumed private in C#
        private List<float> grades;
    }
}
