using System;

namespace ConsoleApp101
{
    class Program
    {
        static void Main(string[] args)
        {
            int hp = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();
            int won = 0;

            while (command != "End of battle")
            {
                int enemy = int.Parse(command);

                if (hp < 0)
                {
                    hp = 0;
                    Console.WriteLine($"Not enough energy! Game ends with {won} won battles and {hp} energy");
                    break;
                }



                if (hp < enemy)
                {
                    Console.WriteLine($"Not enough energy! Game ends with {won} won battles and {hp} energy");
                    break;
                }

                hp -= enemy;

                won++;

                if (won % 3 == 0)
                {
                    hp += won;
                }
                command = Console.ReadLine();
            }

            if (command == "End of battle")
            {
                Console.WriteLine($"Won battles: {won}. Energy left: {hp}");
            }
        }
    }
}