namespace Homework2.Exercise1
{
    public class Hotel : IHotel
    {
        public List<IHotelRoom> Rooms { get; }

        public Hotel()
        {
            // The List of rooms available in the hotel. Should be initialized in the constructor
            Rooms = new List<IHotelRoom>();

        }

        // Add a room to the list of rooms.
        public void AddRoom(IHotelRoom room)
        {
            if (room.Available())
            {
                Rooms.Add(room);
            }
        }

        // Let all guests in all rooms stay for a night and leave if their amount of days left in stay reaches 0
        // Returns all leaving guests.
        public List<IGuest> CheckOut()
        {
            List<IGuest> CheckoutGuests = new List<IGuest>();

            for (int k = Rooms.Count - 1; k >= 0; k--)
            {
                List<IGuest> Guests = Rooms[k].Guests;

                int days;
                for (int j = Guests.Count - 1; j >= 0; j--)
                {
                    days = Guests[j].DaysLeftInStay;
                    days--;
                    Guests[j].DaysLeftInStay = days;

                    if (Guests[j].DaysLeftInStay == 0)
                    {
                        CheckoutGuests.Add(Guests[j]);  // Voeg gasten toe aan de lijst van gasten die uitchecken
                        Guests.RemoveAt(j); // Verwijder uitcheckende gasten uit de kamer
                    }
                }

            }
            return CheckoutGuests;
        }

        // check a new group of guests into the hotel. 
        // find a room where all guests fit (and no other guest is currently staying). 
        // if you cannot find such a room you can throw an InvalidOperationException().
        public void CheckIn(List<IGuest> guests)
        {
            int j = 0; // index van de kleinste kamer waarin de gasten passen
            List<IHotelRoom> CheckinRooms = new List<IHotelRoom>();
            for (int i = Rooms.Count - 1; i >= 0; i--)
            {
                var room = Rooms[i];

                if (guests.Count <= room.Size && (room.Available()))    // gasten passen in de kamer en de kamer is beschikbaar
                {
                    CheckinRooms.Add(room);

                    if ((i < Rooms.Count - 1) && (room.Size > Rooms[i + 1].Size)) // Wanneer j<>0 én wanneer de grootte van de huidige kamer>vorige kamer, behoud dan de laatste waarde van j 
                    {
                        j = j + 0;
                    }
                    else
                    {
                        j = i;
                    }

                }
                else { }
            }


            if (CheckinRooms.Count == 0)
            {
                throw new InvalidOperationException();
            }
            else
            {
                Rooms[j].CheckIn(guests);
            }
        }
    }
}
