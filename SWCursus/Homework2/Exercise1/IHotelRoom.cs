using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Exercise1
{
    public interface IHotelRoom
    {
        // The maximum amount of guests the room can contain. 
        public int Size { get; }

        // A List of all guests currently in the room 
        public List<IGuest> Guests { get; }

        // A method that returns true if the room is currently empty or false if the room isn't
        public bool Available();

        // A group of guests checks in to the room. They should be added to the guest list.
        // When the room is not available an InvalidOperationException should be thrown.
        // When there are to many guests to fit in the room an IndexOutOfRangeException should be thrown.
        public void CheckIn(List<IGuest> guests);

        // Every Day guests have a nice sleep and get a chance to checkout. 
        // This method should reduce the amount of days left all guests their stays by one. 
        // If a guest has 0 days left in their stay after the number was decreased the guest should be removed from the room. 
        public List<IGuest> Checkout();
    }
}
