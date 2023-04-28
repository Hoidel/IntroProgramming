namespace Dag1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(-2 % 7);
            Console.WriteLine(-7 % 7);
            Console.WriteLine(-8 % 7);
        }

        static void StringManipulator()
        {
            Console.WriteLine();
            Console.WriteLine("0) Terug");

            ConsoleKeyInfo i = Console.ReadKey();
            switch (i.KeyChar)
            {
                case '0':
                    return;
                default:
                    return;
            }
        }
    }
}