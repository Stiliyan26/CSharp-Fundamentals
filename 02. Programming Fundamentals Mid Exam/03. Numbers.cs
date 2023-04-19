using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp96
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            double avr = numbers.Average();

            int[] res = numbers
                .Where(x => x > avr)
                .OrderByDescending(x => x)
                .Take(5)
                .ToArray();

            if (res.Length == 0)
            {
                Console.WriteLine("No");
            }

            else
            {
                Console.WriteLine(string.Join(" ", res));
            }

        }
    }
}