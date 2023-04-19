using System;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp160
{

    class City
    {
        public int Population { get; set; }

        public int Gold { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, City> name = new Dictionary<string, City>();

            string command = Console.ReadLine();

            while (command != "Sail")
            {
                string[] parts = command
               .Split("||", StringSplitOptions.RemoveEmptyEntries)
               .ToArray();

                string city = parts[0];
                int population = int.Parse(parts[1]);
                int gold = int.Parse(parts[2]);

                if (!name.ContainsKey(city))
                {
                    name.Add(city, new City
                    {
                        Population = population,
                        Gold = gold
                    });
                }

                else
                {
                    name[city].Gold += gold;
                    name[city].Population += population;
                }



                command = Console.ReadLine();
            }

            string line = Console.ReadLine();

            while (line != "End")
            {
                string[] tokens = line
                    .Split("=>", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                switch (type)
                {
                    case "Plunder":

                        string town = tokens[1];
                        Console.WriteLine($"{tokens[1]} plundered! {tokens[3]} gold stolen, {tokens[2]} citizens killed.");

                        name[town].Population -= int.Parse(tokens[2]);
                        name[town].Gold -= int.Parse(tokens[3]);

                        if (name[town].Population <= 0 || name[town].Gold <= 0)
                        {
                            name.Remove(town);
                            Console.WriteLine($"{town} has been wiped off the map!");
                        }
                        break;

                    case "Prosper":

                        string town2 = tokens[1];
                        int gold = int.Parse(tokens[2]);

                        if (gold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                            line = Console.ReadLine();
                            continue;
                        }

                        else
                        {
                            name[town2].Gold += gold;
                            Console.WriteLine($"{gold} gold added to the city treasury. {town2} now has {name[town2].Gold} gold.");
                        }
                        break;
                }

                line = Console.ReadLine();
            }

            Dictionary<string, City> sorted = name
                .OrderByDescending(g => g.Value.Gold)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine($"Ahoy, Captain! There are {sorted.Count} wealthy settlements to go to:");

            if (sorted.Count != 0)
            {
                foreach (var item in sorted)
                {
                    Console.WriteLine($"{item.Key} -> Population: {item.Value.Population} citizens, Gold: {item.Value.Gold} kg");
                }
            }

            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}