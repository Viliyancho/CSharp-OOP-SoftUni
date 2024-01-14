namespace Telephony
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in numbers)
            {
                if(item.Length == 7)
                {
                    Console.WriteLine(stationaryPhone.Call(item));
                }
                else if(item.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(item)); 
                }
                else
                {
                    Console.WriteLine("Error!");
                }
            }

            foreach (var item in urls)
            {
                Console.WriteLine(smartphone.Browse(item)); 
            }
        }
    }
}