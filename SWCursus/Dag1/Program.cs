namespace Dag1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1) StringManipulator");

            ConsoleKeyInfo i = Console.ReadKey();
            switch (i.KeyChar)
            {
                case '1':
                    StringManipulator();
                    break;
                default:
                    return;
            }
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