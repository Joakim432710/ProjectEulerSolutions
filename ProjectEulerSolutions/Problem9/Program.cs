using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem0
{
    class Program
    {
        /*
         
            A Pythagorean triplet is a set of three natural numbers, a < b < c, for which,

            a2 + b2 = c2
            For example, 32 + 42 = 9 + 16 = 25 = 52.

            There exists exactly one Pythagorean triplet for which a + b + c = 1000.
            Find the product abc.
             
        */

        static void Main(string[] args)
        {
            var products = new List<long>();

            //Find a<b<c such that a+b+c = 1000
            for (var a = 0; a < 1000; ++a)
                for (var b = 0; b < 1000; ++b)
                {
                    if (a >= b) continue;
                    var tmpC = Math.Sqrt((a * a) + (b * b)); //Find c
                    if (b >= (long)tmpC || Math.Abs(tmpC - (int)tmpC) > double.Epsilon) continue; //Make sure b < c and c is a whole number
                    long c = (long)tmpC;
                    if ((a + b + c) != 1000) continue;
                    products.Add(a * b * c);
                }

            Console.WriteLine(products.Max());
            Console.ReadLine();
        }
    }
}
