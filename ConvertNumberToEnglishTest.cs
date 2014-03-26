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
        readonly string[] _numbersUpTo19 = new[] {"", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        readonly string[] _namesOfTens = new[] { "", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };


        [TestCase(1, "one")]
        [TestCase(2, "two")]
        [TestCase(3, "three")]
        [TestCase(20, "twenty")]
        [TestCase(21, "twenty one")]
        [TestCase(30, "thirty")]
        [TestCase(35, "thirty five")]
        [TestCase(100, "one hundred")]
        [TestCase(110, "one hundred and ten")]
        [TestCase(556, "five hundred and fifty six")]
        [TestCase(7000, "seven thousand ")]
        [TestCase(11812, "eleven thousand eight hundred and twelve")]
        [TestCase(13014, "thirteen thousand  and fourteen")] 
        public void ShouldConvertToEnglish(int number, string text)
        {
            ToEnglish(number).Should().Be(text);
        }
        
        private string ToEnglish(int number)
        {
            string text = "";

            if ((number / 1000000) > 0)
            {
                text += ToEnglish(number / 1000000) + " million";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                text += ToEnglish(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                text += ToEnglish(number / 100) + " hundred";
                number  %= 100;
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
                text += _numbersUpTo19[number];
            }
            else
            {
                text += _namesOfTens[number/10];

                int remain = number%10;

                if (remain > 0)
                    text += " " + _numbersUpTo19[remain];
            }
            return text;
        }
    }
}
