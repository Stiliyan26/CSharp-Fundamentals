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
            string password = Console.ReadLine();

            string command = Console.ReadLine();

            while (command != "Done")
            {
                string[] parts = command
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string type = parts[0];

                switch (type)
                {
                    case "TakeOdd":

                        StringBuilder sb = new StringBuilder();

                        for (int i = 1; i < password.Length; i += 2)
                        {
                            sb.Append(password[i]);
                        }

                        password = sb.ToString();

                        Console.WriteLine(password);
                        break;

                    case "Cut":

                        int index = int.Parse(parts[1]);
                        int lenght = int.Parse(parts[2]);

                        password = password.Remove(index, lenght);

                        Console.WriteLine(password);


                        break;

                    case "Substitute":

                        string oldStr = parts[1];
                        string newStr = parts[2];

                        if (!password.Contains(oldStr))
                        {
                            Console.WriteLine("Nothing to replace!");
                        }

                        else
                        {
                            password = password.Replace(oldStr, newStr);
                            Console.WriteLine(password);

                        }
                        break;
                }

                command = Console.ReadLine();
            }
            Console.WriteLine($"Your password is: {password}");
        }
    }
}