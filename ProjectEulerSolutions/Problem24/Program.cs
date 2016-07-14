using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem24
{
    class Program
    {
        /*
            A permutation is an ordered arrangement of objects. For example, 3124 is one possible permutation of the digits 1, 2, 3 and 4. If all of the permutations are listed numerically or alphabetically, we call it lexicographic order. The lexicographic permutations of 0, 1 and 2 are:

            012   021   102   120   201   210

            What is the millionth lexicographic permutation of the digits 0, 1, 2, 3, 4, 5, 6, 7, 8 and 9? 
        */
        static void Main(string[] args)
        {
            var numbers = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var numArr = numbers.ToArray();
            for (var iii = 1; iii < 1000000; ++iii)
                ForwardPermutate(numArr);

            foreach (var num in numArr)
                Console.Write(num);
            Console.WriteLine();

            Console.ReadLine();
        }
    
        //Send this the lowest permutation and it will find the next-lowest, repeat 1 million times
        static int[] ForwardPermutate(int[] values)
        {
            var iii = values.Length - 1;
            while (iii > 0 && values[iii - 1] >= values[iii])
                --iii;
            if (iii <= 0) return null; //No more unique permutations

            var jjj = values.Length - 1;
            while (values[jjj] <= values[iii - 1])
                --jjj;

            //Swap iii - 1 and jjj
            var tmp = values[iii - 1];
            values[iii - 1] = values[jjj];
            values[jjj] = tmp;

            jjj = values.Length - 1; //Reverse end
            while(iii < jjj)
            {
                tmp = values[iii];
                values[iii] = values[jjj];
                values[jjj] = tmp;
                ++iii;
                --jjj;
            }
            return values;
        }
    }
}
