
namespace Homework2.Exercise1
{
    public class HotelRoom : IHotelRoom
    {
        public int Size { get; }    // The maximum amount of guests the room can contain. 

        public HotelRoom(int size)
        {
            Size = size;
        }
        public List<IGuest> Guests { get; } = new List<IGuest>(); // A List of all guests currently in the room

        // A method that returns true if the room is currently empty or false if the room isn't
        public bool Available()
        {
            // wanneer de som van de gasten in de kamer nul is, dan waar
            if (Guests.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // A group of guests checks in to the room. They should be added to the guest list.
        // When the room is not available an InvalidOperationException should be thrown.
        // When there are to many guests to fit in the room an IndexOutOfRangeException should be thrown.
        public void CheckIn(List<IGuest> guests)
        {
            if (!Available())
            {
                throw new InvalidOperationException();
            }
            // Wanneer de gasten die nog willen inchecken met meer zijn dan hoeveel in de kamer passen
            else if (guests.Count > Size)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                // Voor elke variabele guest van type Guest in checkin-lijst guests,
                foreach (Guest guest in guests)
                {
                    //wordt een guest aan de kamerlijst Guests toegevoegd.
                    Guests.Add(guest);
                }
            }
        }

        // Every Day guests have a nice sleep and get a chance to checkout.
        // This method should reduce the amount of days left all guests their stays by one. 
        // If a guest has 0 days left in their stay after the number was decreased the guest should be removed from the room. 
        public List<IGuest> Checkout()
        {
            int days;
            for (int j = Guests.Count - 1; j >= 0; j--)
            {
                days = Guests[j].DaysLeftInStay;
                days--;
                Guests[j].DaysLeftInStay = days;

                if (Guests[j].DaysLeftInStay <= 0)
                {
                    Guests.RemoveAt(j);
                }
            }
            return Guests;
        }
    }
}