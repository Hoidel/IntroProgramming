using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Exercise2
{
    public interface IHotel
    {
        // The List of rooms available in the hotel. Should be initialized in the constructor
        public List<IHotelRoom> Rooms { get; }

        // Add a room to the list of rooms.
        public void AddRoom(IHotelRoom room);

        // Let all guests in all rooms stay for a night and leave if their amount of days left in stay reaches 0
        // Returns all leaving guests. 
        public List<IGuest> CheckOut();

        // check a new group of guests into the hotel. 
        // find a room where all guests fit (and no other guest is currently staying). 
        // if you cannot find such a room you can throw an InvalidOperationException().
        public void CheckIn(List<IGuest> guests);
    }
}
