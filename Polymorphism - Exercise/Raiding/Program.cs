
using Raiding.Models;
using Raiding.Models.Interfaces;

namespace Raiding
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HashSet<IBaseHero> all = new();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                switch (type)
                {
                    case "Druid":
                        Druid druid = new Druid(name, 80);
                        all.Add(druid);
                        break;
                    case "Paladin":
                        Paladin paladin = new Paladin(name, 100);
                        all.Add(paladin);
                        break;
                    case "Rogue":
                        Rogue rogue = new Rogue(name, 80);
                        all.Add(rogue);
                        break;
                    case "Warrior":
                        Warrior warrior = new Warrior(name, 100);
                        all.Add(warrior);   
                        break;
                    default:
                        Console.WriteLine("Invalid hero!");
                        break;
                }

            }
            int villain = int.Parse(Console.ReadLine());
            int sumPower = 0;
            foreach (var item in all)
            {
                sumPower += item.Power;
                Console.WriteLine(item.CastAbility());
            }
            if(sumPower>= villain)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine($"Defeat...");
            }
        }
    }
}