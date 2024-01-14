using System.Security.Cryptography.X509Certificates;

namespace FoodShortage
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<IBuyer> all = new List<IBuyer>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 3)
                {
                    Rebel rebel = new Rebel(input[0], int.Parse(input[1]), input[2]);
                    all.Add(rebel);
                }
                else if (input.Length == 4)
                {
                    Citizen citizen = new Citizen(input[0], int.Parse(input[1]), input[2], input[3]);
                    all.Add(citizen);
                }
            }

            string something = string.Empty;

            while ((something = Console.ReadLine()) != "End")
            {
                if(all.Any(x=>x.Name == something))
                {
                    all.FirstOrDefault(x => x.Name == something).BuyFood();
                }
            }
            int food = 0;
            foreach (var item in all)
            {
                food += item.Food;
            }
            Console.WriteLine(food);
        }
    }
}