using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace PlantDiscovery
{
    class Cars
    {
        public int Milage { get; set; }
        public int Fuel { get; set; }
    }
    class PlantDiscovery
    {
        static void Main(string[] args)
        {
            Dictionary<string, Cars> car = new Dictionary<string, Cars>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                if (!car.ContainsKey(parts[0]))
                {
                    car.Add(parts[0], new Cars());
                }

                car[parts[0]].Milage = int.Parse(parts[1]);
                car[parts[0]].Fuel = int.Parse(parts[2]);
            }

            string command = Console.ReadLine();

            while (command != "Stop")
            {
                string[] tokens = command
                    .Split(" : ", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                switch (type)
                {
                    case "Drive":

                        string model = tokens[1];
                        int distance = int.Parse(tokens[2]);
                        int fuel = int.Parse(tokens[3]);

                        if (car[model].Fuel >= fuel)
                        {
                            car[model].Milage += distance;
                            car[model].Fuel -= fuel;
                            Console.WriteLine($"{model} driven for {distance} kilometers. {fuel} liters of fuel consumed.");
                        }

                        else
                        {
                            Console.WriteLine($"Not enough fuel to make that ride");
                        }

                        if (car[model].Milage >= 100000)
                        {
                            car.Remove(model);
                            Console.WriteLine($"Time to sell the {model}!");
                        }

                        break;

                    case "Refuel":
                        string model2 = tokens[1];
                        int fuel2 = int.Parse(tokens[2]);

                        int oldRef = car[model2].Fuel;
                        int result = 0;

                        car[model2].Fuel += fuel2;

                        if (car[model2].Fuel > 75)
                        {
                            car[model2].Fuel = 75;
                            result = car[model2].Fuel - oldRef;
                        }

                        else
                        {
                            result = fuel2;
                        }

                        Console.WriteLine($"{model2} refueled with {result} liters");
                        break;

                    case "Revert":
                        string model3 = tokens[1];
                        int km = int.Parse(tokens[2]);

                        car[model3].Milage -= km;
                        Console.WriteLine($"{model3} mileage decreased by {km} kilometers");

                        if (car[model3].Milage < 10000)
                        {
                            car[model3].Milage = 10000;
                        }

                        break;
                }

                command = Console.ReadLine();
            }

            Dictionary<string, Cars> sortedCars = car
                .OrderByDescending(m => m.Value.Milage)
                .ThenBy(n => n.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in sortedCars)
            {
                Console.WriteLine($"{item.Key} -> Mileage: {item.Value.Milage} kms, Fuel in the tank: {item.Value.Fuel} lt.");
            }
        }
    }
}
