using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        public string FullName => throw new NotImplementedException();

        public int Category => throw new NotImplementedException();

        public double Turnover => throw new NotImplementedException();

        public IRepository<IRoom> Rooms => throw new NotImplementedException();

        public IRepository<IBooking> Bookings => throw new NotImplementedException();
    }
}
