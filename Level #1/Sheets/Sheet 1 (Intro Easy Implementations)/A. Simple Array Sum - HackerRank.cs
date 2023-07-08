using System;
using System.Linq;

namespace ProblemSolving
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var i = Console.ReadLine();
            var input = Console.ReadLine().TrimEnd().Split(' ').ToArray();
            var arr = Array.ConvertAll(input, int.Parse);

            Console.WriteLine(arr.Sum());
        }
    }
}