namespace Homework2.Exercise1
{
    public class Guest : IGuest
    {
        public Guest(string name, int daysLeftInStay)
        {
            Name = name;
            DaysLeftInStay = daysLeftInStay;
        }

        public string Name { get; }
        public int DaysLeftInStay { get; set; }
    }
}
