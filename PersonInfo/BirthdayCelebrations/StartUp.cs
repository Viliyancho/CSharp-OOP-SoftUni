namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<iBirthable> all = new List<iBirthable>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] parameters = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (parameters[0] == "Citizen")
                {
                    Citizen citizen = new Citizen(parameters[1], int.Parse(parameters[2]), parameters[3], parameters[4]);
                    all.Add(citizen);
                }
                else if (parameters[0] == "Pet")
                {
                    Pet pet = new Pet(parameters[1], parameters[2]);
                    all.Add(pet);
                }
                else
                {
                    continue;
                }
            }
            string year = Console.ReadLine();

            foreach (var item in all)
            {
                if(item.Birthdate.EndsWith(year))
                {
                    Console.WriteLine(item.Birthdate);
                }
            }
            
        }
    }
}