using System;
using FluentValidation;

namespace Bookify.Application.Bookings.ReserveBooking;

public class ReserveBookingCommandValidator:AbstractValidator<ReserveBookingCommand>
{
    public ReserveBookingCommandValidator(){
        RuleFor(x=>x.UserId).NotEmpty();
        RuleFor(x=>x.UserId).NotNull();
        RuleFor(x=>x.ApartmentId).NotNull();
        RuleFor(x=>x.StartDate).LessThan(x=>x.EndDate);;
    }
}
