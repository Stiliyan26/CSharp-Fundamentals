using System;
using System.Linq;

namespace ConsoleApp101
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] targets = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int shots = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "End")
                {
                    break;
                }

                int shotIndx = int.Parse(command);

                if (shotIndx >= targets.Length)
                {
                    continue;
                }

                int value = targets[shotIndx];

                for (int i = 0; i < targets.Length; i++)
                {
                    if (targets[i] == -1)
                    {
                        continue;
                    }

                    else if (value < targets[i])
                    {
                        targets[i] -= value;
                    }

                    else
                    {
                        targets[i] += value;
                    }
                }

                targets[shotIndx] = -1;

                shots++;

            }
            Console.Write($"Shot targets: {shots} -> ");
            Console.Write(string.Join(" ", targets));

        }
    }
}