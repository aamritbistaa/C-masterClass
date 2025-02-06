using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookify.Infrastructure.Repositories
{
    internal class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration)
        {
            throw new NotImplementedException();
        }

        Task IBookingRepository.Add(Booking booking)
        {
            throw new NotImplementedException();
        }

        Task<Booking> IBookingRepository.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
