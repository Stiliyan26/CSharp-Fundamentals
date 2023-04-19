using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp158
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string pattern = @"@#+(?<name>[A-Z][A-Za-z0-9]{4,}[A-Z])@#+";
            Regex digitPattern = new Regex(@"\d");

            List<string> matchingbarcodes = new List<string>();


            for (int i = 0; i < n; i++)
            {
                string product = Console.ReadLine();

                Match match = Regex.Match(product, pattern);

                if (!match.Success)
                {
                    Console.WriteLine("Invalid barcode");
                }

                else
                {
                    MatchCollection matches = digitPattern.Matches(match.Groups["name"].Value);
                    string nums = string.Empty;

                    if (matches.Count > 0)
                    {
                        foreach (var item in matches)
                        {
                            nums += item;
                        }

                    }

                    else
                    {
                        nums = "00";
                    }

                    Console.WriteLine($"Product group: {nums}");
                }
            }
        }
    }
}