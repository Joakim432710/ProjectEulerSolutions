using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem14
{
    class Program
    {
        /*
            The following iterative sequence is defined for the set of positive integers:

            n → n/2 (n is even)
            n → 3n + 1 (n is odd)

            Using the rule above and starting with 13, we generate the following sequence:

            13 → 40 → 20 → 10 → 5 → 16 → 8 → 4 → 2 → 1
            It can be seen that this sequence (starting at 13 and finishing at 1) contains 10 terms. Although it has not been proved yet (Collatz Problem), it is thought that all starting numbers finish at 1.

            Which starting number, under one million, produces the longest chain?

            NOTE: Once the chain starts the terms are allowed to go above one million.
        */

        //Working and easy recursive solution, unfortunately the stack lengths are too long
        //private static int GetCollatzLength(int n, List<int> list = null)
        //{
        //    if (list == null) list = new List<int>();
        //    if (n == 1) return 1;
        //    int newCollatz = n;
        //    if ((n % 2) == 0) newCollatz /= 2;
        //    else
        //    {
        //        newCollatz *= 3;
        //        newCollatz += 1;
        //    }
        //    return GetCollatzLength(newCollatz) + 1;
        //}

        private static int GetCollatzLength(long n)
        {
            if (n <= 1) return 1;
            var count = 1;
            while(n != 1)
            {
                if ((n % 2) == 0) n /= 2;
                else
                {
                    n *= 3;
                    n += 1;
                }
                ++count;
            }
            return count;
        }

        static void Main(string[] args)
        {
            GetCollatzLength(113383);

            var maxLength = 0;
            var maxNumber = 1;
            for(var iii = 1; iii < 1000000; ++iii)
            {
                var length = GetCollatzLength(iii);
                if (length > maxLength)
                {
                    maxNumber = iii;
                    maxLength = length;
                    Console.WriteLine("New max length: " + length + " at number: " + iii);
                }
            }

            Console.WriteLine("Finished! Length: " + maxLength + " at number: " + maxNumber + ". Answer: " + maxNumber);
            Console.ReadLine();
        }
    }
}
