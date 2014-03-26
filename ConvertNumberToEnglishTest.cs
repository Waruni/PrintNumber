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

        [TestCase(20)]
        public void Convert20ToTwentyTest(int number)
        {
            ToEnglish(number).Should().Be("twenty");
        }

        [TestCase(21)]
        public void Convert21ToTwentyOneTest(int number)
        {
            ToEnglish(number).Should().Be("twenty one");
        }
         

        [TestCase(30)]
        public void Convert30ToThirtyTest(int number)
        {
            ToEnglish(number).Should().Be("thirty");
        }

        [TestCase(35)]
        public void Convert35ToThirtyFiveTest(int number)
        {
            ToEnglish(number).Should().Be("thirty five");
        }

        [TestCase(100)]
        public void Convert100ToOneHundredTest(int number)
        {
            ToEnglish(number).Should().Be("one hundred");
        }

        [TestCase(110)]
        public void Convert110ToOneHundredAndTenTest(int number)
        {
            ToEnglish(number).Should().Be("one hundred and ten");
        }


        [TestCase(556)]
        public void Convert556ToFiveHundredAndFiftySixTest(int number)
        {
            ToEnglish(number).Should().Be("five hundred and fifty six");
        }


        private string ToEnglish(int number)
        {
            string text = ""; 
            
            var numbersUpTo19 = new[] {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
            var numbersFromTen = new[] {"", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"  };

            if ((number / 100) > 0)
            {
                text += ToEnglish(number / 100) + " hundred";
                number  = number % 100;
            }

            if (number > 0)
            {
                if (text != "")
                {
                    text += " and ";
                }

                if (number < 20)
                {
                    text += numbersUpTo19[number - 1];
                }
                else
                {
                    text += numbersFromTen[number/10];

                    int remain = number % 10;

                    if (remain > 0)
                        text += " " + numbersUpTo19[remain - 1];
                }
            }
            return text;
        }
    }
}
