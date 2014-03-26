using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using FluentAsserts;

namespace PrintNumber
{
    public class ConvertNumberToEnglishTest
    {
        [TestCase(1)]
        public void Convert1ToOneTest(int number)
        {
            ToEnglish(number).Should().Be("one");
        }

        [TestCase(2)]
        public void Convert2ToTwoTest(int number)
        {
            ToEnglish(number).Should().Be("two");
        }

        [TestCase(3)]
        public void Convert3ToThreeTest(int number)
        {
            ToEnglish(number).Should().Be("three");
        }

        private string ToEnglish(int number)
        {
            string text = "";

            if (number == 1)
            {
                text = "one";
            }
            if (number == 2)
            {
                text = "two";
            }
            if (number == 3)
            {
                text = "three";
            }
            return text;
        }
    }
}
