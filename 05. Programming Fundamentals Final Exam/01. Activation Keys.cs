using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp160
{
	class Program
	{
		static void Main(string[] args)
		{
			string message = Console.ReadLine();

			string command = Console.ReadLine();

			while (command != "Generate")
			{
				string[] parts = command
					.Split(">>>", StringSplitOptions.RemoveEmptyEntries);

				string type = parts[0];

				switch (type)
				{
					case "Contains":

						string substr = parts[1];

						if (message.Contains(substr))
						{
							Console.WriteLine($"{message} contains {substr}");
						}

						else
						{
							Console.WriteLine($"Substring not found!");
						}
						break;

					case "Flip":

						string typeCase = parts[1];
						int startIdx = int.Parse(parts[2]);
						int endIdx = int.Parse(parts[3]);

						string old = message.Substring(startIdx, endIdx - startIdx);

						if (typeCase == "Upper")
						{
							string replace = message.Substring(startIdx, endIdx - startIdx).ToUpper();
							message = message.Replace(old, replace);
						}

						else if (typeCase == "Lower")
						{
							string replace = message.Substring(startIdx, endIdx - startIdx).ToLower();
							message = message.Replace(old, replace);
						}

						Console.WriteLine(message);
						break;

					case "Slice":

						int start = int.Parse(parts[1]);
						int end = int.Parse(parts[2]);

						message = message.Remove(start, end - start);
						Console.WriteLine(message);
						break;
				}


				command = Console.ReadLine();
			}
			Console.WriteLine($"Your activation key is: {message}");
		}
	}
}