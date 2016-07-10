using System;
using System.Numerics;

namespace Problem16
{
    class Program
    {
        /*
            215 = 32768 and the sum of its digits is 3 + 2 + 7 + 6 + 8 = 26.

            What is the sum of the digits of the number 21000?
        */
        static void Main(string[] args)
        {
            var num = BigInteger.Pow(2, 1000);
            var result = 0;
            foreach (var c in num.ToString())
                result += byte.Parse(c.ToString());
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
