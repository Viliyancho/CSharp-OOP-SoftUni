using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        public void AddNew(IHotel model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IHotel> All()
        {
            throw new NotImplementedException();
        }

        public IHotel Select(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
