using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp144
{
    class Pices
    {
        public string Composer { get; set; }
        public string Keys { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Pices> name = new Dictionary<string, Pices>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                string[] parts = line
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string piece = parts[0];
                string c = parts[1];
                string k = parts[2];

                name.Add(piece, new Pices
                {
                    Composer = c,
                    Keys = k
                });
            }

            while (true)
            {
                string command = Console.ReadLine();

                string[] tokens = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                if (type == "Stop")
                {
                    break;
                }

                if (type == "Add")
                {
                    string pices = tokens[1];
                    string composer = tokens[2];
                    string key = tokens[3];

                    if (!name.ContainsKey(pices))
                    {
                        name.Add(pices, new Pices
                        {
                            Composer = tokens[2],
                            Keys = tokens[3]
                        });

                        Console.WriteLine($"{pices} by {composer} in {key} added to the collection!");
                    }

                    else
                    {
                        Console.WriteLine($"{pices} is already in the collection!");
                    }
                }

                else if (type == "Remove")
                {
                    string pices = tokens[1];

                    if (name.ContainsKey(pices))
                    {
                        name.Remove(pices);
                        Console.WriteLine($"Successfully removed {pices}!");
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {pices} does not exist in the collection.");
                    }
                }

                else if (type == "ChangeKey")
                {
                    string pice = tokens[1];
                    string newKey = tokens[2];

                    if (name.ContainsKey(pice))
                    {
                        name[pice].Keys = newKey;

                        Console.WriteLine($"Changed the key of {pice} to {newKey}!");
                    }

                    else
                    {
                        Console.WriteLine($"Invalid operation! {pice} does not exist in the collection.");
                    }
                }
            }

            Dictionary<string, Pices> sorted = name
                .OrderBy(x => x.Key)
                .ThenBy(e => e.Value.Composer)
                .ToDictionary(a => a.Key, a => a.Value);

            foreach (var item in sorted)
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value.Composer}, Key: {item.Value.Keys}");

            }
        }
    }
}