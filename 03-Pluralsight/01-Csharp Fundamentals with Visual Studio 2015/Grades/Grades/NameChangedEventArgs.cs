using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // the ": EventArgs" is how you do inheretence in C#
    // EventArgs comes form the .NET library, for events
    public class NameChangedEventArgs : EventArgs
    {
        // this is the class for storing the event arguments for the delegate call

        // prop <tab> <tab> creates a blank property
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
