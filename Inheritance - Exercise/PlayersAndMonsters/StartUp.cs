namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            BladeKnight bn = new BladeKnight("Viliyan", 33);
            System.Console.WriteLine(bn.ToString());
        }
    }
}