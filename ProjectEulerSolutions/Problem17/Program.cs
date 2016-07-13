using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem17
{
    class Program
    {
        /*
            If the numbers 1 to 5 are written out in words: one, two, three, four, five, then there are 3 + 3 + 5 + 4 + 4 = 19 letters used in total.
            If all the numbers from 1 to 1000 (one thousand) inclusive were written out in words, how many letters would be used?                       
            NOTE: Do not count spaces or hyphens. For example, 342 (three hundred and forty-two) contains 23 letters and 115 (one hundred and fifteen) contains 20 letters. The use of "and" when writing out numbers is in compliance with British usage.
        */
        static void Main(string[] args)
        {
            var result = "";

            var cache = new Dictionary<int, string>();

            var d = new Dictionary<int, string>
            {
                [0] = "",
                [1] = "one",
                [2] = "two",
                [3] = "three",
                [4] = "four",
                [5] = "five",
                [6] = "six",
                [7] = "seven",
                [8] = "eight",
                [9] = "nine",
                [10] = "ten",
                [11] = "eleven",
                [12] = "twelve",
                [13] = "thirteen",
                [14] = "fourteen",
                [15] = "fifteen",
                [16] = "sixteen",
                [17] = "seventeen",
                [18] = "eighteen",
                [19] = "nineteen",
                [20] = "twenty",
                [30] = "thirty",
                [40] = "forty",
                [50] = "fifty",
                [60] = "sixty",
                [70] = "seventy",
                [80] = "eighty",
                [90] = "ninety",
                [100] = "hundred",
                [1000] = "thousand",
            };

            for (var iii = 1; iii <= 20; ++iii)
            { 
                result += d[iii] + Environment.NewLine;
                cache.Add(iii, d[iii]);
            }

            for (var iii = 21; iii < 100; ++iii)
            {
                var tens = 10 * (iii / 10);
                var ones = iii - tens;
                result += d[tens] + d[ones] + Environment.NewLine;
                cache.Add(iii, d[tens] + d[ones]);
            }

            for (var iii = 100; iii < 1000; ++iii)
            {
                var tmpresult = "";

                var hundreds = 100 * (iii / 100);

                tmpresult = d[hundreds/100] + " " + d[100];

                var tens = 10 * ((iii - hundreds) / 10);
                var ones = iii - hundreds - tens;

                if (tens != 0 || ones != 0)
                    tmpresult += " and " + cache[tens + ones];

                result += tmpresult + Environment.NewLine;
            }

            result += d[1] + " " + d[1000] + Environment.NewLine;

            //var hundred = "hundred";

            //for(var iii = 1; iii <= 1000; ++iii)

            Console.WriteLine(result);
            Console.WriteLine("Total of: " + result.Replace(" ", string.Empty).Replace(Environment.NewLine, string.Empty).Count() + " characters.");
            Console.ReadLine();
        }
    }
}
