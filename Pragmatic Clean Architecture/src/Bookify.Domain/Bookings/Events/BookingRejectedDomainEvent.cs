using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public record class BookingRejectedDomainEvent(Guid bookingId) : IDomainEvent;