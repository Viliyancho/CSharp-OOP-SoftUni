using RestaurantEx;

namespace Restaurant
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Tea tea = new Tea("absd", 123, 123);

            System.Console.WriteLine(tea.Name);
        }
    }
}