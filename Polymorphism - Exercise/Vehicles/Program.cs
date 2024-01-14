using Vehicles.Models;

namespace Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]));

            string[] truckArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]));

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (input[1] == "Car")
                {
                    MethodForCar(input, car);
                }
                else if (input[1] == "Truck")
                {
                    MethodForTruck(input, truck);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
        }
        public static void MethodForCar(string[] input, Car car)
        {
            if (input[0] == "Drive")
            {
                Console.WriteLine(car.Drive(double.Parse(input[2]))); 
            }
            else if (input[0] == "Refuel")
            {
                car.Refuel(double.Parse(input[2]));
            }
        }
        public static void MethodForTruck(string[] input, Truck truck)
        {
            if (input[0] == "Drive")
            {
                Console.WriteLine(truck.Drive(double.Parse(input[2])));
            }
            else if (input[0] == "Refuel")
            {
                truck.Refuel(double.Parse(input[2]));
            }
        }
    }
}