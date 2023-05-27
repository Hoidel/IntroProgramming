using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework2.Exercise1
{
    public class HotelRoom : IHotelRoom
    {

        public int Size;
        public List<IGuest> Guests;
        public int maxDagen;

        public HotelRoom(int size)
        {
            Size = size;
        }

        public Boolean Available():
        {
            if (Guests.Count() = 0)
            {
                return true;
            }

            return false;
        }

        // A group of guests checks in to the room. They should be added to the guest list.
        // When the room is not available an InvalidOperationException should be thrown.
        // When there are to many guests to fit in the room an IndexOutOfRangeException should be thrown.
        public void CheckIn(List<IGuest> guests)
        {
            if (!Available())
            {
                throw InvalidOperationException("Ruimte is niet beschikbaar")
            }
            else if (guests.Count > size)
            {
                throw IndexOutOfRangeException("Te veel gasten voor deze kamer")
            }
            else
            {

                Guests = guests;
                int i = 0;
                foreach (Guest gastje in Guests)
                {
                   if(i < gastje.DaysLeftInStay)
                    {
                        maxDagen = i;
                    }
                }
                
            }
        }

        // Every Day guests have a nice sleep and get a chance to checkout. 
        // This method should reduce the amount of days left all guests their stays by one. 
        // If a guest has 0 days left in their stay after the number was decreased the guest should be removed from the room. 
        public List<IGuest> Checkout()
        {
            if (maxDagen = 0)
            {
                Guests.RemoveAll();
            }

            else
            {
                maxDagen = maxDagen - 1;
            }

        }


    }
}
