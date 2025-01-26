using System;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new("Booking.NotFound", "The booking with specified identifier was not found.");


}
