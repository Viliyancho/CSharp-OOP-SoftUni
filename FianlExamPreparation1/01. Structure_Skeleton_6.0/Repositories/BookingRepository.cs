using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        public void AddNew(IBooking model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IBooking> All()
        {
            throw new NotImplementedException();
        }

        public IBooking Select(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
