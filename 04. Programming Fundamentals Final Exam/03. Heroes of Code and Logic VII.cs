using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp158
{
    class Hp
    {
        public int HP { get; set; }
        public int MP { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Hp> hero = new Dictionary<string, Hp>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] parts = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = parts[0];

                if (!hero.ContainsKey(name))
                {
                    hero.Add(name, new Hp());
                }

                hero[name].HP = int.Parse(parts[1]);
                hero[name].MP = int.Parse(parts[2]);

                if (hero[name].HP > 100)
                {
                    hero[name].HP = 100;
                }

                if (hero[name].MP > 200)
                {
                    hero[name].MP = 200;
                }
            }

            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] tokens = command
                    .Split(" - ", StringSplitOptions.RemoveEmptyEntries);

                string type = tokens[0];

                switch (type)
                {
                    case "CastSpell":

                        string heroName = tokens[1];
                        int mpNeeded = int.Parse(tokens[2]);
                        string spellName = tokens[3];

                        if (hero[heroName].MP >= mpNeeded)
                        {
                            hero[heroName].MP -= mpNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {hero[heroName].MP} MP!");
                        }

                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }

                        break;

                    case "TakeDamage":

                        string hrName = tokens[1];
                        int damage = int.Parse(tokens[2]);
                        string attacker = tokens[3];

                        hero[hrName].HP -= damage;

                        if (hero[hrName].HP > 0)
                        {
                            Console.WriteLine($"{hrName} was hit for {damage} HP by {attacker} and now has {hero[hrName].HP} HP left!");
                        }

                        else
                        {
                            hero.Remove(hrName);
                            Console.WriteLine($"{hrName} has been killed by {attacker}!");
                        }

                        break;

                    case "Recharge":

                        string theHeroName = tokens[1];
                        int amount = int.Parse(tokens[2]);

                        int oldMp = hero[theHeroName].MP;

                        hero[theHeroName].MP += amount;
                        int neededAmount = 0;

                        if (hero[theHeroName].MP > 200)
                        {
                            neededAmount = 200 - oldMp;
                            hero[theHeroName].MP = 200;

                        }

                        else
                        {
                            neededAmount = amount;
                        }

                        Console.WriteLine($"{theHeroName} recharged for {neededAmount} MP!");
                        break;

                    case "Heal":

                        string nameHero = tokens[1];
                        int amount2 = int.Parse(tokens[2]);

                        int oldHp = hero[nameHero].HP;

                        hero[nameHero].HP += amount2;

                        int neededHp = 0;

                        if (hero[nameHero].HP > 100)
                        {
                            neededHp = 100 - oldHp;
                            hero[nameHero].HP = 100;
                        }

                        else
                        {
                            neededHp = amount2;
                        }

                        Console.WriteLine($"{nameHero} healed for {neededHp} HP!");
                        break;
                }

                command = Console.ReadLine();
            }

            foreach (var item in hero.OrderByDescending(h => h.Value.HP).ThenBy(n => n.Key))
            {
                Console.WriteLine(item.Key);
                Console.WriteLine($"  HP: {item.Value.HP}");
                Console.WriteLine($"  MP: {item.Value.MP}");
            }
        }
    }
}