using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp101
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                string[] parts = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = parts[0];
                int index = int.Parse(parts[1]);
                int power = int.Parse(parts[2]);

                switch (type)
                {
                    case "Shoot":

                        if (ifExists(targets, index))
                        {
                            targets[index] -= power;

                            if (targets[index] <= 0)
                            {
                                targets.RemoveAt(index);
                            }
                        }
                        break;

                    case "Add":

                        if (ifExists(targets, index))
                        {
                            targets.Insert(index, power);
                        }

                        else
                        {
                            Console.WriteLine($"Invalid placement!");
                        }
                        break;

                    case "Strike":

                        if (!ifExists(targets, index))
                        {
                            Console.WriteLine($"Strike missed!");
                        }

                        else
                        {

                            int startIdx = index - power;

                            if (startIdx < 0)
                            {
                                startIdx = 0;
                            }

                            if (startIdx == index)
                            {
                                Console.WriteLine($"Strike missed!");
                                break;
                            }

                            int count = power * 2 + 1;

                            if (count > targets.Count - startIdx)
                            {
                                Console.WriteLine($"Strike missed!");
                                break;

                            }

                            targets.RemoveRange(startIdx, count);
                        }
                        break;
                }


            }
            Console.WriteLine(string.Join("|", targets));

        }

        private static bool ifExists(List<int> targets, int index)
        {

            foreach (var item in targets)
            {
                int idx = targets.IndexOf(item);

                if (idx == index)
                {
                    return true;
                }
            }

            return false;
        }
    }
}