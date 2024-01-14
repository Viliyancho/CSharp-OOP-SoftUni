using VehicleExtension.Models;

namespace VehicleExtension
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] carArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Car car = new Car(double.Parse(carArgs[1]), double.Parse(carArgs[2]), double.Parse(carArgs[3]));

            string[] truckArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Truck truck = new Truck(double.Parse(truckArgs[1]), double.Parse(truckArgs[2]), double.Parse(truckArgs[3]));

            string[] busArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            Bus bus = new Bus(double.Parse(busArgs[1]), double.Parse(busArgs[2]), double.Parse(busArgs[3]));

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
                else if(input[1] == "Bus")
                {
                    MethodForBus(input, bus);
                }
            }

            Console.WriteLine($"Car: {car.FuelQuantity:f2}");
            Console.WriteLine($"Truck: {truck.FuelQuantity:f2}");
            Console.WriteLine($"Bus: {bus.FuelQuantity:f2}");
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

        public static void MethodForBus(string[] input, Bus bus)
        {
            if (input[0] == "Drive")
            {
                Console.WriteLine(bus.DriveBus(double.Parse(input[2]), input[0]));
            }
            else if (input[0] == "Refuel")
            {
                bus.Refuel(double.Parse(input[2]));
            }
            else if(input[0] == "DriveEmpty")
            {
                Console.WriteLine(bus.DriveBus(double.Parse(input[2]), input[0]));
            }
        }
    }
}