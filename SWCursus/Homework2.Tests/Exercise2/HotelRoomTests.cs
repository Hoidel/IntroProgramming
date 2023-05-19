using Homework2.Exercise2;

namespace Homework2.Tests
{
    public class HotelRoomTests
    {
        [Fact]
        public void Constructor()
        {
            IHotelRoom room1 = new HotelRoom(2);

            Assert.Equal(2, room1.Size);
            Assert.Empty(room1.Guests);
        }

        [Fact]
        public void Available_True()
        {
            IHotelRoom room1 = new HotelRoom(2);

            Assert.True(room1.Available());
        }

        [Fact]
        public void Available_False()
        {
            IHotelRoom room1 = new HotelRoom(2);
            room1.Guests.Add(new Guest("Mark", 3));

            Assert.True(room1.Available());
        }

        [Fact]
        public void Checkin_Valid()
        {
            IHotelRoom room1 = new HotelRoom(2);

            List<IGuest> guests = new List<IGuest>();
            guests.Add(new Guest("Mark", 3));
            guests.Add(new Guest("Joop", 2));

            room1.CheckIn(guests);

            Assert.Equal(2, room1.Guests.Count);
        }

        [Fact]
        public void Checkin_NotEmpty()
        {
            IHotelRoom room1 = new HotelRoom(2);

            List<IGuest> guests = new List<IGuest>();
            guests.Add(new Guest("Mark", 3));
            guests.Add(new Guest("Joop", 2));

            room1.CheckIn(guests);

            Assert.Throws<InvalidOperationException>(() => room1.CheckIn(guests));
        }

        [Fact]
        public void Checkin_TooSmall()
        {
            IHotelRoom room1 = new HotelRoom(1);

            List<IGuest> guests = new List<IGuest>();
            guests.Add(new Guest("Mark", 3));
            guests.Add(new Guest("Joop", 2));

            Assert.Throws<IndexOutOfRangeException>(() => room1.CheckIn(guests));
        }

        [Fact]
        public void Checkout_Day()
        {
            IHotelRoom room1 = new HotelRoom(2);

            room1.Guests.Add(new Guest("Mark", 3));
            room1.Guests.Add(new Guest("Joop", 2));

            Assert.Equal(3, room1.Guests[0].DaysLeftInStay);
            Assert.Equal(2, room1.Guests[1].DaysLeftInStay);

            room1.Checkout();

            Assert.Equal(2, room1.Guests[0].DaysLeftInStay);
            Assert.Equal(1, room1.Guests[1].DaysLeftInStay);
        }

        [Fact]
        public void Checkout_OneLeaves()
        {
            IHotelRoom room1 = new HotelRoom(2);

            room1.Guests.Add(new Guest("Mark", 3));
            room1.Guests.Add(new Guest("Joop", 2));

            room1.Checkout();

            Assert.Equal(2, room1.Guests[0].DaysLeftInStay);
            Assert.Equal(1, room1.Guests[1].DaysLeftInStay);

            room1.Checkout();

            Assert.Equal(1, room1.Guests[0].DaysLeftInStay);
            Assert.Single(room1.Guests);
        }

        [Fact]
        public void Checkout_BothLeave()
        {
            IHotelRoom room1 = new HotelRoom(2);

            room1.Guests.Add(new Guest("Mark", 2));
            room1.Guests.Add(new Guest("Joop", 2));

            room1.Checkout();

            Assert.Equal(1, room1.Guests[0].DaysLeftInStay);
            Assert.Equal(1, room1.Guests[1].DaysLeftInStay);

            room1.Checkout();

            Assert.Empty(room1.Guests);
        }
    }
}