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
        readonly string[] _numbersUpTo19 = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        readonly string[] _numbersFromTen = new[] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


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

        [TestCase(7000)]
        public void Convert7000ToSevenThousandTest(int number)
        {
            ToEnglish(number).Should().Be("seven thousand ");
        }

        [TestCase(11812)]
        public void Convert11812ToElevenThousandEightHundredAndTwelveTest(int number)
        {
            ToEnglish(number).Should().Be("eleven thousand eight hundred and twelve");
        }

        [TestCase(13014)]
        public void Convert13014ToThirteenThousandAndFourteenTest(int number)
        {
            ToEnglish(number).Should().Be("thirteen thousand  and fourteen");
        }

        private string ToEnglish(int number)
        {
            string text = "";  

            if ((number / 1000) > 0)
            {
                text += ToEnglish(number / 1000) + " thousand ";
                number = number % 1000;
            }

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

                text = NumberLessThan100(number, text);
            }
            return text;
        }

        private string NumberLessThan100(int number, string text)
        {
            if (number < 20)
            {
                text += _numbersUpTo19[number - 1];
            }
            else
            {
                text += _numbersFromTen[number/10];

                int remain = number%10;

                if (remain > 0)
                    text += " " + _numbersUpTo19[remain - 1];
            }
            return text;
        }
    }
}
