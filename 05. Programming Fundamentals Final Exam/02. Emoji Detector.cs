using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp160
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<string> nameOf = new List<string>();
            int count = 0;
            int coolCount = 0;
            long coolThresHold = 1;

            Regex regex = new Regex(@"(\::|\*\*)(?<name>[A-Z][a-z]{2,})\1");
            Regex digits = new Regex(@"\d");

            MatchCollection namesMatched = regex.Matches(input);
            MatchCollection digitMatches = digits.Matches(input);

            foreach (Match numbers in digitMatches)
            {
                coolThresHold *= int.Parse(numbers.Value);
            }

            foreach (Match item in namesMatched)
            {
                string name = item.Groups["name"].Value;
                int ascciValue = 0;

                for (int i = 0; i < name.Length; i++)
                {
                    ascciValue += (char)(name[i]);
                }

                if (coolThresHold <= ascciValue)
                {
                    nameOf.Add(item.Value);
                    coolCount++;
                }

                count++;

            }

            Console.WriteLine($"Cool threshold: {coolThresHold}");
            Console.WriteLine($"{count} emojis found in the text. The cool ones are:");


            if (coolCount != 0)
            {
                foreach (var item in nameOf)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}