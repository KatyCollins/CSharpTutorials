using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatesAndTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime myValue = DateTime.Now;

            // This string is defined by your system settings
            // Console.WriteLine(myValue.ToString());

            // shows just the date
            // Console.WriteLine(myValue.ToShortDateString());

            // Shows just the time
            // Console.WriteLine(myValue.ToShortTimeString());

            // Long version of the date
            // Console.WriteLine(myValue.ToLongDateString());

            // Long version of time
            // Console.WriteLine(myValue.ToLongTimeString());

            /////////////////////////////////////////////////

            // Console.WriteLine(myValue.AddDays(3).ToLongDateString());
            // Console.WriteLine(myValue.AddHours(3).ToLongTimeString());

            // Console.WriteLine(myValue.AddDays(-3).ToLongDateString());
            // Console.WriteLine(myValue.AddHours(-3).ToLongTimeString());

            // numberic month
            // Console.WriteLine(myValue.Month);

            // 12/7/1969 entered into a date field
            // DateTime myBirthday = new DateTime(1969, 12, 7);
            // Console.WriteLine(myBirthday.ToShortDateString());

            DateTime myBirthday = DateTime.Parse("12/7/1969");
            TimeSpan myAge = DateTime.Now.Subtract(myBirthday);
            Console.WriteLine(myAge.TotalDays);

            Console.ReadLine();
        }
    }
}
