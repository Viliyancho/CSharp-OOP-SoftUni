using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        [SetUp]
        public void Setup()
        {
            hotel = new Hotel("Sunny Garden", 5);
        }

        [Test]
        public void ConstructorWorksCorrectly()
        {
            Assert.AreEqual(hotel.FullName, "Sunny Garden");
            Assert.AreEqual(hotel.Category, 5);
        }

        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        [TestCase("    ")]
        public void InvalidNameThrowsException(string fullName)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(fullName, 3));
        }

        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(6)]
        [TestCase(10)]
        public void InvalidCategoryRateThrowsException(int category)
        {
            Assert.Throws<ArgumentException>(() => new Hotel("Sunny Garden", category));
        }

        [Test]
        public void AddRoomsCorrectly()
        {
            Room room1 = new Room(5, 200);

            Room room2 = new Room(3, 150);

            hotel.AddRoom(room1);

            Assert.AreEqual(hotel.Rooms.Count, 1);

            hotel.AddRoom(room2);

            Assert.AreEqual(hotel.Rooms.Count, 2);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        public void BookRoomThrowsExceptionWhileNegativeAdults(int adults)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, 11, 12, 100));
        }

        [TestCase(-1)]
        [TestCase(-5)]
        public void BookRoomThrowsExceptionWhileNegativeChildren(int children)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(5, children, 12, 100));
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-5)]
        public void BookRoomThrowsExceptionWhileNegativeDuration(int duration)
        {
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(5, 11, duration, 100));
        }

        [Test]
        public void BookRoomWorksCorrectly()
        {
            Room room1 = new Room(5, 100);
            Room room2 = new Room(8, 120);
            Room room3 = new Room(15, 150);

            hotel.AddRoom(room1);
            hotel.AddRoom(room2);
            hotel.AddRoom(room3);

            hotel.BookRoom(4, 7, 3, 500);

            Assert.AreEqual(hotel.Bookings.Count, 1);
            Assert.AreEqual(hotel.Turnover, 450);
        }

        [TearDown]
        public void TearDown()
        {
            hotel = null;
        }
    }
}