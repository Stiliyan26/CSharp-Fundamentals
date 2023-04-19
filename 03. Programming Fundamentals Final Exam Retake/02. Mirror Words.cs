using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class PlantDiscovery
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            List<string> mirror = new List<string>();

            Regex regex = new Regex(@"(([@|#])(?<name1>[A-Za-z]{3,})\2{2}(?<name2>[A-Za-z]{3,})\2)");

            MatchCollection pairs = regex.Matches(text);

            if (pairs.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }

            else
            {
                Console.WriteLine($"{pairs.Count} word pairs found!");
            }

            foreach (Match item in pairs)
            {
                string first = item.Groups["name1"].Value;
                string second = item.Groups["name2"].Value;

                string reversed = string.Empty;

                for (int i = second.Length - 1; i >= 0; i--)
                {
                    reversed += second[i];
                }

                if (reversed == first)
                {
                    string result = $"{first} <=> {second}";
                    mirror.Add(result);
                }
            }

            if (mirror.Count == 0)
            {
                Console.WriteLine("No mirror words!");
            }

            else
            {
                Console.WriteLine("The mirror words are:");
                Console.WriteLine(string.Join(", ", mirror));
            }
        }
    }
}