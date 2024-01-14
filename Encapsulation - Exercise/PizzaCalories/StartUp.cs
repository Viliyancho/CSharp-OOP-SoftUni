namespace PizzaCalories
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = string.Empty;
            try
            {
                string[] pizzaTokens = Console.ReadLine().Split();
                string[] doughTokens = Console.ReadLine().Split();

                string pizzaName = pizzaTokens[1];

                Dough dough = new(doughTokens[1], doughTokens[2], double.Parse(doughTokens[3]));

                Pizza pizza = new(pizzaName, dough);
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] commandArgs = input.Split();

                        Topping topping = new Topping(commandArgs[1], double.Parse(commandArgs[2]));
                        pizza.AddTopping(topping);


                }
            

                Console.WriteLine(pizza);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}