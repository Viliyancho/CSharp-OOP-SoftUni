using PersonInfo;

namespace BorderControl
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable> all = new List<IIdentifiable>();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "End")
            {
                string[] parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (parameters.Length == 3)
                {
                    Citizen citizen = new Citizen(parameters[0], int.Parse(parameters[1]), parameters[2]);
                    all.Add(citizen);
                }
                else if(parameters.Length == 2)
                {
                    Robot robot = new Robot(parameters[0], parameters[1]);
                    all.Add(robot);
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }
            string newOne = Console.ReadLine();

            foreach (var item in all)
            {
                if(item.Id.EndsWith(newOne))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}