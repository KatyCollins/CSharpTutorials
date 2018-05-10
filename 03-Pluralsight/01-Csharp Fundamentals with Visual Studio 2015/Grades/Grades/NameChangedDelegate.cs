using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    // public delegate void NameChangedDelegate(string existingName, string newName);

    /*
     * as a best practice for this, there are usually 2 parms for a delegate
     * 1 - the sender of the event (IE - what program triggered it)
     * 2 - this is the part that contains all of the parameters that you will need
     * 
     * because of this, you may need to create a seperate 
     * class to create the structure for the parms.
     * See NameChangedEventArgs.cs for how we did it here
     */

    // the object parm in this one means you could send anything through this.
    public delegate void NameChangedDelegate(object sender, NameChangedEventArgs args);
}
