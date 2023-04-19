using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp144
{
    class Food
    {
        public string Name { get; set; }
        public string Date { get; set; }
        public int Calories { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();

            Regex regex = new Regex(@"([#||])(?<name>[A-Za-z\s]+)\1(?<date>(\d{2}\/\d{2}\/\d{2}))\1(?<calories>(\d{1,5}))\1");

            MatchCollection match = regex.Matches(text);

            List<Food> listOfFood = new List<Food>();

            int sumOfCals = 0;
            int days = 0;

            foreach (Match food in match)
            {
                listOfFood.Add(new Food()
                {
                    Name = food.Groups["name"].Value,
                    Date = food.Groups["date"].Value,
                    Calories = int.Parse(food.Groups["calories"].Value)
                });

                int cal = int.Parse(food.Groups["calories"].Value);
                sumOfCals += cal;
            }

            while (sumOfCals >= 2000)
            {
                sumOfCals -= 2000;
                days++;
            }

            Console.WriteLine($"You have food to last you for: {days} days!");

            foreach (var food in listOfFood)
            {
                Console.WriteLine($"Item: {food.Name}, Best before: {food.Date}, Nutrition: {food.Calories}");
            }
        }
    }
}