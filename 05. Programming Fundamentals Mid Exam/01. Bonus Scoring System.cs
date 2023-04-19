using System;

namespace ConsoleApp97
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lectureCount = int.Parse(Console.ReadLine());
            int bonus = int.Parse(Console.ReadLine());

            double totalBonus = 0;
            double currentMax = 0;
            double currentIdx = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int atendance = int.Parse(Console.ReadLine());

                totalBonus = (double)atendance / lectureCount * (5 + bonus);

                if (totalBonus > currentMax)
                {
                    currentMax = totalBonus;
                    currentIdx = atendance;
                }
            }

            Console.WriteLine($"Max Bonus: {Math.Ceiling(currentMax)}.");
            Console.WriteLine($"The student has attended {Math.Ceiling(currentIdx)} lectures.");
        }
    }
}