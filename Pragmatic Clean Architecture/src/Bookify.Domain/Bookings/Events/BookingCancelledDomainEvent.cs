using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Bookings.Events;

public record class BookingCancelledDomainEvent(Guid Id) : IDomainEvent;
