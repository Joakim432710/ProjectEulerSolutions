using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem20
{
    class Program
    {
        static void Main(string[] args)
        {
            var value = new BigInteger(100);
            for (var iii = 99; iii > 0; --iii)
                value = BigInteger.Multiply(value, iii);
            Console.WriteLine("100! = " + value);
            Console.WriteLine("Sum of digits in 100!: " + value.ToString().Sum(c => byte.Parse(c.ToString())));
            Console.ReadLine();
        }
    }
}
