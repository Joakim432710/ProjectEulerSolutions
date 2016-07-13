using System;
using System.IO;
using System.Linq;
namespace Problem67
{
    class Program
    {
        /*
            By starting at the top of the triangle below and moving to adjacent numbers on the row below, the maximum total from top to bottom is 23.

            3
            7 4
            2 4 6
            8 5 9 3

            That is, 3 + 7 + 4 + 9 = 23.

            Find the maximum total from top to bottom in triangle.txt (right click and 'Save Link/Target As...'), a 15K text file containing a triangle with one-hundred rows.

            NOTE: This is a much more difficult version of Problem 18. It is not possible to try every route to solve this problem, as there are 299 altogether! If you could check one trillion (1012) routes every second it would take over twenty billion years to check them all. There is an efficient algorithm to solve it. ;o)
            
            Developer's note: Chose to use a min/max path solution to this also used to solve problem 18
            The image explanation.png explains it all
        */


        static void Main(string[] args)
        {
            var data = ReadInputFromFile("data.txt");
            var simplified = Simplify(data[data.Length - 2], data[data.Length - 1]);

            for (var iii = data.Length - 1; iii > 0; --iii)
                data[iii - 1] = Simplify(data[iii - 1], data[iii]);

            Console.WriteLine("Max Path: " + data[0][0]);
            Console.ReadLine();
        }

        private static long[][] ReadInputFromFile(string file)
        {
            var text = File.ReadAllLines(file);
            var ret = new long[text.Length][];

            var row = 0;
            var column = -1;
            foreach (var line in text)
            {
                ret[row] = new long[text.Length];
                foreach (var number in line.Split(' ').Select(str => long.Parse(str))) ret[row][++column] = number;
                column = -1;
                ++row;
            }


            return ret;
        }

        private static long[] Simplify(long[] parents, long[] children)
        {
            var ret = new long[parents.Length];
            for (var iii = 0; iii < ret.Length; ++iii)
                ret[iii] = parents[iii] + Math.Max(children[iii], (iii + 1) < children.Length ? children[iii + 1] : 0);
            return ret;
        }
    }
}
