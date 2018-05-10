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
            _name = "Empty";
            grades = new List<float>();
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            float sum = 0;
            foreach (float grade in grades)
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

        // if public is not defined, it is assumed private in C#
        private List<float> grades;

        ///////////////////////////////////////////////////////////////
            // field vs property and delegate vs event logic here
        ///////////////////////////////////////////////////////////////

        // changing this from a field to a property
        // you generally want to do this for any public values
        // it lets you add validation logic for "set"
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    // this is an example of event/delegate
                    if (_name != value)
                    {
                        // NameChanged(_name, value);

                        NameChangedEventArgs args = new NameChangedEventArgs();

                        args.ExistingName = _name;
                        args.NewName = value;

                        // "this" references the current object
                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }

        // to change this from a delegate to an event, 
        // all you have to do is add the word "event"
        /*
         * The benefit of using an event over a deligate is that
         * you can not directly assign (=) a value to it 
         * you can only add (+=) or remove (-=) items
         */
        public event NameChangedDelegate NameChanged;

    }
}
