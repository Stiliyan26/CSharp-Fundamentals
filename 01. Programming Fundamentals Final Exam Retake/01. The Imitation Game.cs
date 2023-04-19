using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;



namespace ConsoleApp143
{
    class Program
    {
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            StringBuilder sb = new StringBuilder(line);

            while (true)
            {
                string[] parts = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                if (parts[0] == "Decode")
                {
                    break;
                }

                if (parts[0] == "Move")
                {
                    int n = int.Parse(parts[1]);

                    for (int i = 0; i < n; i++)
                    {
                        sb.Append(sb[i]);
                    }


                    sb.Remove(0, n);
                }

                else if (parts[0] == "Insert")
                {
                    int index = int.Parse(parts[1]);
                    string value = parts[2];

                    sb.Insert(index, value);
                }

                else if (parts[0] == "ChangeAll")
                {
                    string substr = parts[1];
                    string replacement = parts[2];

                    sb.Replace(substr, replacement);
                }
            }

            string message = sb.ToString();

            Console.WriteLine($"The decrypted message is: {message}");
        }
    }
}