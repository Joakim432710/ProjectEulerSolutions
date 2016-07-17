using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Problem25
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new BigInteger(1); //F(1)
            var b = new BigInteger(1); //F(2)
            var c = a + b; //F(3)
            var index = 3; 
            while(c.ToString().Length < 1000)
            {
                a = b;
                b = c;
                c = a + b;
                ++index;
            }
            Console.WriteLine("First fib number with 1000 digits: " + c);
            Console.WriteLine("It's index: " + index);
            Console.ReadLine();
        }
    }
}
