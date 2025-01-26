using System;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Bookings;

public interface IBookingRepository
{
    Task<bool> IsOverlappingAsync(Apartment apartment, DateRange duration);

    Task Add(Booking booking);
}
