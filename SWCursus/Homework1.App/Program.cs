namespace Homework1.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DayCalculator calculator = new DayCalculator();
            int dayNumber = calculator.DayOfWeekFirstJanuaryCurrentYear();
            Console.WriteLine($"Als 28 april 2023 op een vrijdag valt, viel 1 januari 2023 op een {calculator.GetDay(dayNumber)}");
        }
    }
}