using Homework2.Exercise1;

namespace Homework2.Tests.Exercise1
{
    public class HotelTests
    {
        [Fact]
        public void MainTest()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            IHotelRoom room2 = new HotelRoom(2);

            IHotelRoom room3 = new HotelRoom(4);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            List<IGuest> guests1 = new List<IGuest>();
            guests1.Add(new Guest("Mark", 2));
            guests1.Add(new Guest("Joop", 3));
            guests1.Add(new Guest("Karel", 1));

            List<IGuest> guests2 = new List<IGuest>();
            guests2.Add(new Guest("Gertje", 1));
            guests2.Add(new Guest("Bertje", 1));

            List<IGuest> guests3 = new List<IGuest>();
            guests3.Add(new Guest("Jannus", 5));
            guests3.Add(new Guest("Hannus", 1));

            List<IGuest> guests4 = new List<IGuest>();
            guests4.Add(new Guest("Willem", 10));
            guests4.Add(new Guest("Willie", 10));
            guests4.Add(new Guest("Wonka", 10));

            hotel.CheckIn(guests1);
            hotel.CheckIn(guests2);
            hotel.CheckIn(guests3);

            Assert.Throws<InvalidOperationException>(() => hotel.CheckIn(guests4));

            List<IGuest> leavers1 = hotel.CheckOut();
            Assert.Equal(4, leavers1.Count);
            Assert.Contains(leavers1, guest => guest.Name == "Karel");
            Assert.Contains(leavers1, guest => guest.Name == "Gertje");
            Assert.Contains(leavers1, guest => guest.Name == "Bertje");
            Assert.Contains(leavers1, guest => guest.Name == "Hannus");

            Assert.Throws<InvalidOperationException>(() => hotel.CheckIn(guests4));

            List<IGuest> leavers2 = hotel.CheckOut();
            Assert.Single(leavers2);
            Assert.Contains(leavers2, guest => guest.Name == "Mark");

            Assert.Throws<InvalidOperationException>(() => hotel.CheckIn(guests4));

            List<IGuest> leavers3 = hotel.CheckOut();
            Assert.Single(leavers3);
            Assert.Contains(leavers3, guest => guest.Name == "Joop");

            hotel.CheckIn(guests4);
        }

        [Fact]
        public void AddRoom()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            IHotelRoom room2 = new HotelRoom(3);

            hotel.AddRoom(room1);

            Assert.Contains(room1, hotel.Rooms);
            Assert.Contains(room2, hotel.Rooms);

            Assert.Equal(2, hotel.Rooms.Count);
        }

        [Fact]
        public void Checkout_Single()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            room1.Guests.Add( new Guest("Mark", 2));

            hotel.Rooms.Add(room1);

            List<IGuest> leavers = hotel.CheckOut();

            Assert.Empty(leavers);
            Assert.Equal(1, hotel.Rooms[0].Guests[0].DaysLeftInStay);
        }

        [Fact]
        public void Checkout_SingleStayOver()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            room1.Guests.Add(new Guest("Mark", 2));

            hotel.Rooms.Add(room1);

            List<IGuest> leavers1 = hotel.CheckOut();
            List<IGuest> leavers2 = hotel.CheckOut();

            Assert.Empty(leavers1);
            Assert.Single(leavers2);
        }

        [Fact]
        public void Checkout_Many()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            room1.Guests.Add(new Guest("Mark", 2));
            hotel.Rooms.Add(room1);

            IHotelRoom room2 = new HotelRoom(4);
            room2.Guests.Add(new Guest("Joop", 3));
            room2.Guests.Add(new Guest("Gertje", 2));
            room2.Guests.Add(new Guest("Bertje", 2));
            hotel.Rooms.Add(room2);

            List<IGuest> leavers1 = hotel.CheckOut();
            Assert.Empty(leavers1);

            List<IGuest> leavers2 = hotel.CheckOut();
            Assert.Equal(3, leavers2.Count);
            Assert.Contains(leavers2, guest => guest.Name == "Mark");
            Assert.Contains(leavers2, guest => guest.Name == "Gertje");
            Assert.Contains(leavers2, guest => guest.Name == "Bertje");

            List<IGuest> leavers3 = hotel.CheckOut();
            Assert.Single(leavers3);
            Assert.Contains(leavers3, guest => guest.Name == "Joop");

            List<IGuest> leavers4 = hotel.CheckOut();
            Assert.Empty(leavers4);
        }

        [Fact]
        public void CheckIn_Available()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            hotel.Rooms.Add(room1);

            List<IGuest> guests = new List<IGuest>();
            guests.Add(new Guest("Mark", 2));
            guests.Add(new Guest("Joop", 3));

            hotel.CheckIn(guests);

            Assert.Equal(2, hotel.Rooms[0].Guests.Count);
        }

        [Fact]
        public void CheckIn_UnAvailable()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            room1.Guests.Add(new Guest("Mark", 2));
            hotel.Rooms.Add(room1);

            List<IGuest> guests = new List<IGuest>();
            guests.Add(new Guest("Joop", 3));

            Assert.Throws<InvalidOperationException>(() => hotel.CheckIn(guests));
        }

        [Fact]
        public void CheckIn_Size()
        {
            IHotel hotel = new Hotel();

            IHotelRoom room1 = new HotelRoom(2);
            hotel.Rooms.Add(room1);

            List<IGuest> guests = new List<IGuest>();
            guests.Add(new Guest("Mark", 2));
            guests.Add(new Guest("Joop", 3));
            guests.Add(new Guest("Gertje", 4));

            Assert.Throws<InvalidOperationException>(() => hotel.CheckIn(guests));
        }
    }
}