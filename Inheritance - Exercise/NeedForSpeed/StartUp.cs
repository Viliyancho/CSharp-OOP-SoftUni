using System.IO;
using System.Security.Cryptography;

namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            RaceMotorcycle rm = new RaceMotorcycle(100, 240);

            rm.Drive(10);
            System.Console.WriteLine(rm.Fuel);
        }
    }
}
