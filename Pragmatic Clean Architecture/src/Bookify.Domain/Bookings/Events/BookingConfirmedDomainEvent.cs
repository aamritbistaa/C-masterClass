using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public record class BookingConfirmedDomainEvent(Guid bookingId) : IDomainEvent;