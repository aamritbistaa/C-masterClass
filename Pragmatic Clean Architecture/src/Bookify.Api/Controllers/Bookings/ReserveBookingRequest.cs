using System;

namespace Bookify.Api.Controllers.Bookings;

public class ReserveBookingRequest
{
    public Guid ApartmentId { get; set; }
    public Guid UserId { get; set; }
    public DateOnly StartDate { get; set; }
    public DateOnly EndDate { get; set; }
}
