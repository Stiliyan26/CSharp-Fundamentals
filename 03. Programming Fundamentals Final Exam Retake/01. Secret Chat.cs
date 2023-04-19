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
            StringBuilder message = new StringBuilder(Console.ReadLine());

            string command = Console.ReadLine();

            while (command != "Reveal")
            {
                string[] tokens = command
                    .Split(":|:", StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "InsertSpace":
                        int index = int.Parse(tokens[1]);
                        message.Insert(index, " ");
                        Console.WriteLine(message.ToString());
                        break;

                    case "Reverse":
                        string substr = tokens[1];

                        if (message.ToString().Contains(substr))
                        {
                            int startIdx = message.ToString().IndexOf(substr);
                            int endIdx = substr.Length;
                            string rev = string.Empty;

                            for (int i = substr.Length - 1; i >= 0; i--)
                            {
                                rev += substr[i];
                            }

                            message.Append(rev);
                            message.Remove(startIdx, endIdx);
                            Console.WriteLine(message.ToString());

                        }

                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;

                    case "ChangeAll":

                        string sub = tokens[1];
                        string replacement = tokens[2];
                        message.Replace(sub, replacement);
                        Console.WriteLine(message.ToString());

                        break;
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"You have a new text message: {message.ToString()}");
        }
    }
}