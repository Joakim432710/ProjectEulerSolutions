using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem23
{
    class Program
    {
        /*
            A perfect number is a number for which the sum of its proper divisors is exactly equal to the number. For example, the sum of the proper divisors of 28 would be 1 + 2 + 4 + 7 + 14 = 28, which means that 28 is a perfect number.

            A number n is called deficient if the sum of its proper divisors is less than n and it is called abundant if this sum exceeds n.

            As 12 is the smallest abundant number, 1 + 2 + 3 + 4 + 6 = 16, the smallest number that can be written as the sum of two abundant numbers is 24. By mathematical analysis, it can be shown that all integers greater than 28123 can be written as the sum of two abundant numbers. However, this upper limit cannot be reduced any further by analysis even though it is known that the greatest number that cannot be expressed as the sum of two abundant numbers is less than this limit.

            Find the sum of all the positive integers which cannot be written as the sum of two abundant numbers.
        */
        static void Main(string[] args)
        {

            var abudantNumbers = new List<long>();
            for (var iii = 2; iii <= 28123; ++iii)
                if (GetDivisors(iii).Sum() > iii)
                    abudantNumbers.Add(iii);

            bool[] hasAbundantSum = new bool[28124];            

            for (var iii = 0; iii < abudantNumbers.Count; ++iii)
                for (var jjj = iii; jjj < abudantNumbers.Count; ++jjj)
                {
                    var tmpSum = abudantNumbers[iii] + abudantNumbers[jjj];
                    if (tmpSum > 28123) break;
                    hasAbundantSum[tmpSum] = true;
                }


            Console.WriteLine("All numbers which cannot be written as the sum of two abundant numbers:");
            var sum = 0;
            for (var iii = 1; iii <= 28123; ++iii)
                if (!hasAbundantSum[iii])
                    sum += iii;

            Console.WriteLine("Their sum: " + sum);
            Console.ReadLine();
        }

        static List<int> GetDivisors(int n)
        {
            var ret = new List<int> { 1 };

            var sqrtN = Math.Sqrt(n);
            for (var iii = 2; iii <= sqrtN; ++iii)
                if ((n % iii) == 0)
                {
                    ret.Add(iii);
                    if (iii != (n / iii))
                        ret.Add(n / iii);
                }
            ret.Sort();
            return ret;
        }
    }
}
