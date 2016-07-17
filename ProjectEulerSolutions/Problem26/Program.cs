using System;
using System.Collections.Generic;
using System.Numerics;

namespace Problem26
{
    class Program
    {
        static void Main(string[] args)
        {
            var lenLongestCycle = 0;
            var longestNumber = 0;

            var number = 999;
            while(lenLongestCycle < number)
            {
                var remainders = new List<int>();
                var currentRemainder = 1; // 1 / n will always give 1 remainder for any n > 1
                while(!remainders.Contains(currentRemainder))
                {
                    remainders.Add(currentRemainder);
                    currentRemainder *= 10;
                    currentRemainder %= number;
                }
                if (remainders.Count > lenLongestCycle)
                {
                    lenLongestCycle = remainders.Count;
                    longestNumber = number;
                }
                --number;
            }


            Console.WriteLine("The longest cycle with length: " + lenLongestCycle);
            Console.WriteLine("Was found for d: " + longestNumber);
            Console.ReadLine();
        }
    }
}
