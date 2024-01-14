using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        public void AddNew(IRoom model)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<IRoom> All()
        {
            throw new NotImplementedException();
        }

        public IRoom Select(string criteria)
        {
            throw new NotImplementedException();
        }
    }
}
