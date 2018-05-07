using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {
        // testm <tab><tab> creates a blank test method
        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;

            Assert.AreNotEqual(x1, x2);

        }
        [TestMethod]
        public void GradeBookVariablesHoldAReference1()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1.Name = "Katy's grade book";
            Assert.AreEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference2()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook(); // if this was not here, g2 would show g1's name
            g1.Name = "Katy's grade book";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Katy";
            string name2 = "katy";

            bool result = string.Equals(name1, name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void ReferenceTypesPassByValue1()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName1(book2);
            Assert.AreEqual("A GradeBook", book1.Name);

        }

        private void GiveBookAName1(GradeBook book)
        {
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void ValueTypesPassByValue1()
        {
            int x = 46;
            IncrementNumber1(x);

            Assert.AreEqual(46, x);
        }

        private void IncrementNumber1(int number)
        {
            number++;
        }

        // another example of above, only passing by reference instead
        [TestMethod]
        public void ReferenceTypesPassByValue2()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookAName2(ref book2);
            Assert.AreEqual("A GradeBook", book2.Name);

        }

        private void GiveBookAName2(ref GradeBook book)
        {
            book = new GradeBook();
            book.Name = "A GradeBook";
        }

        // this shows the difference between ref and out
        // when you use out, the compiler expects output for that value
        [TestMethod]
        public void ValueTypesPassByValue2()
        {
            int x = 46;
            IncrementNumber2(ref x);

            Assert.AreEqual(47, x);
        }

        private void IncrementNumber2(ref int number)
        {
            number++;
        }

        // Example of immutable values
        // they can only be updated, not changed
        [TestMethod]
        public void AddDaystoDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            // date.AddDays(1); // this will fail, did not update value
            date = date.AddDays(1); // this will pass, did update value

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "katy";
            // name.ToUpper(); // this will fail, did not update value
            name = name.ToUpper(); // this will pass, did update value

            Assert.AreEqual("KATY", name);
        }

        // arrays are also passed with a pointer so this will update the value currectly
        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);

        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
        }
    }
}
