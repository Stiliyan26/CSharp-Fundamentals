using System;

namespace ConsoleApp96
{
    class Program
    {
        static void Main(string[] args)
        {
            int f_emp = int.Parse(Console.ReadLine());
            int s_emp = int.Parse(Console.ReadLine());
            int t_emp = int.Parse(Console.ReadLine());

            int students_count = int.Parse(Console.ReadLine());

            int oneHour = f_emp + s_emp + t_emp;
            int hour = 1;

            while (students_count > 0)
            {

                if (hour % 4 == 0)
                {
                    hour++;
                    continue;
                }

                students_count = students_count - oneHour;
                hour++;
            }

            int neededHours = (hour - 1);

            Console.WriteLine($"Time needed: {neededHours}h.");
        }
    }
}