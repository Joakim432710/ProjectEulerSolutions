using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem21
{
    class Program
    {
        /*
            Let d(n) be defined as the sum of proper divisors of n (numbers less than n which divide evenly into n).
            If d(a) = b and d(b) = a, where a ≠ b, then a and b are an amicable pair and each of a and b are called amicable numbers.

            For example, the proper divisors of 220 are 1, 2, 4, 5, 10, 11, 20, 22, 44, 55 and 110; therefore d(220) = 284. The proper divisors of 284 are 1, 2, 4, 71 and 142; so d(284) = 220.

            Evaluate the sum of all the amicable numbers under 10000.
        */
        static void Main(string[] args)
        {
            var numbers = new List<int>();
            var pairs = new List<Tuple<int, int>>();
            for (var iii = 4; iii < 10000; ++iii)
            {
                if (numbers.Contains(iii)) continue;
                var amicable = GetDivisors(iii).Sum();
                if (amicable == iii || GetDivisors(amicable).Sum() != iii) continue;

                numbers.Add(iii);
                numbers.Add(amicable);
                pairs.Add(new Tuple<int, int>(iii, amicable));
            }

            Console.WriteLine("All amicable pairs: ");
            foreach (var pair in pairs)
                Console.WriteLine($"({pair.Item1}, {pair.Item2})");
            Console.WriteLine("There are " + numbers.Count + " amicable numbers less than 10000 and their sum are: " + numbers.Sum());
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
