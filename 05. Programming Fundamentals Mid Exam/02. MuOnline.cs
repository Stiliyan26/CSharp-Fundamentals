using System;
using System.Linq;

namespace ConsoleApp97
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int bestRoom = 1;
            int health = 100;
            int bitcoints = 0;
            int to100hp = 0;


            for (int i = 0; i < rooms.Length; i++)
            {
                string[] parts = rooms[i]
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = parts[0];

                if (command == "potion")
                {

                    health += int.Parse(parts[1]);

                    to100hp = int.Parse(parts[1]);

                    if (health > 100)
                    {
                        int overHp = health - 100;
                        to100hp -= overHp;
                        health -= overHp;
                    }

                    Console.WriteLine($"You healed for {to100hp} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }

                else if (command == "chest")
                {
                    int bit = int.Parse(parts[1]);
                    Console.WriteLine($"You found {bit} bitcoins.");

                    bitcoints += bit;

                }

                else
                {
                    string monsterName = parts[0];
                    int monsterAttak = int.Parse(parts[1]);
                    health -= monsterAttak;

                    if (health > 0)
                    {
                        Console.WriteLine($"You slayed {monsterName}.");
                    }

                    else if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monsterName}.");
                        Console.WriteLine($"Best room: {bestRoom}");
                        break;
                    }

                }

                bestRoom++;
            }

            if (bestRoom == rooms.Length + 1)
            {
                Console.WriteLine($"You've made it!");
                Console.WriteLine($"Bitcoins: {bitcoints}");
                Console.WriteLine($"Health: {health}");
            }
        }
    }
}