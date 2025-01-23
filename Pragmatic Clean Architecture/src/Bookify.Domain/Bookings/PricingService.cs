using System;
using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange range)
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(apartment.Price.Amount * range.LengthInDays, currency);

        decimal percentageUpCharge = 0;

        foreach (var amenity in apartment.Amenities)
        {
            percentageUpCharge += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.5m,
                Amenity.AirConditoning => 0.01m,
                Amenity.Parking => 0.1m,
                _ => 0
            };
        }

        var amenitiesUpCharge = Money.Zero(currency);
        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(percentageUpCharge * priceForPeriod.Amount, priceForPeriod.Currency);
        }
        var totalPrice = Money.Zero();
        totalPrice = totalPrice + amenitiesUpCharge;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }
        return new PricingDetails(priceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}
