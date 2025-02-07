using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Microsoft.EntityFrameworkCore;
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

        private static readonly BookingStatus[] ActiveBookingStatus = {
        BookingStatus.Reserved,
        BookingStatus.Confirmed,
        BookingStatus.Completed
    };

        public async Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration)
        {
            return await _context.Set<Booking>()
                .AnyAsync(booking => booking.ApartmentId == apartment.Id && booking.Duration.StartDate <= duration.EndDate && booking.Duration.EndDate >= duration.StartDate && ActiveBookingStatus.Contains(booking.Status));
        }

        async Task IBookingRepository.Add(Booking booking)
        {
            await base.Add(booking);
        }

        async Task<Booking> IBookingRepository.GetByIdAsync(Guid id)
        {
            return await base.GetByIdAsync(id);
        }

    }
}
