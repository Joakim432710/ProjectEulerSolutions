using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem10
{
    class Program
    {
        /*
            The sum of the primes below 10 is 2 + 3 + 5 + 7 = 17.
            Find the sum of all the primes below two million.
        */

        static void Main(string[] args)
        {
            var primes = new List<long>();
            for(var iii = 2L; iii < 2000000L; ++iii)
            {
                var isPrime = true;
                foreach(var prime in primes)
                {
                    if ((iii % prime) == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (!isPrime) continue;
                primes.Add(iii);
            }


            Console.WriteLine(primes.Sum());
            Console.ReadLine();
        }
    }
}
