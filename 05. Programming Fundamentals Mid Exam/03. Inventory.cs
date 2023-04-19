using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleApp97
{
	class Program
	{
		static void Main(string[] args)
		{
			List<string> items = Console.ReadLine()
				.Split(", ", StringSplitOptions.RemoveEmptyEntries)
				.ToList();

			string command = Console.ReadLine();

			while (command != "Craft!")
			{
				string[] parts = command
					.Split(" - ", StringSplitOptions.RemoveEmptyEntries);

				string type = parts[0];
				string currentItem = parts[1];

				switch (type)
				{
					case "Collect":

						if (alreadyExists(items, currentItem))
						{
							command = Console.ReadLine();
							continue;
						}

						else
						{
							items.Add(currentItem);
						}
						break;

					case "Drop":

						if (alreadyExists(items, currentItem))
						{
							items.Remove(currentItem);
						}
						break;

					case "Combine Items":

						string[] tokens = parts[1]
							.Split(":", StringSplitOptions.RemoveEmptyEntries);

						string oldElement = tokens[0];
						string newElement = tokens[1];
						int index = 0;

						if (alreadyExists(items, oldElement))
						{
							for (int i = 0; i < items.Count; i++)
							{
								if (items[i] == oldElement)
								{
									index = i;
								}
							}

							items.Insert(index + 1, newElement);
						}
						break;

					case "Renew":

						if (alreadyExists(items, currentItem))
						{
							string renewItem = currentItem;

							items.Remove(currentItem);
							items.Add(renewItem);
						}
						break;

				}


				command = Console.ReadLine();
			}
			Console.Write(string.Join(", ", items));
		}

		private static bool alreadyExists(List<string> items, string currentitem)
		{
			foreach (var item in items)
			{
				if (item == currentitem)
				{
					return true;
				}
			}

			return false;
		}
	}
}