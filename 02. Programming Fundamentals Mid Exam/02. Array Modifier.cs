using System;
using System.Linq;

namespace ConsoleApp96
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                string[] token = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                int firstIndex = 0;
                int secondIndex = 0;

                switch (token[0])
                {
                    case "swap":

                        firstIndex = int.Parse(token[1]);
                        secondIndex = int.Parse(token[2]);
                        int num = arr[firstIndex];
                        arr[firstIndex] = arr[secondIndex];
                        arr[secondIndex] = num;
                        break;

                    case "multiply":
                        firstIndex = int.Parse(token[1]);
                        secondIndex = int.Parse(token[2]);
                        arr[firstIndex] *= arr[secondIndex];
                        break;

                    case "decrease":

                        for (int i = 0; i < arr.Length; i++)
                        {
                            arr[i]--;
                        }
                        break;

                    default:
                        break;

                }

            }
            Console.WriteLine(string.Join(", ", arr));
        }
    }
}