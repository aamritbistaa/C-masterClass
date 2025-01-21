namespace Bookify.Domain.Bookings;

public record DateRange
{
    private DateRange()
    {

    }

    public DateOnly StartDate { get; init; }
    public DateOnly EndDate { get; init; }
    public int LengthInDays => EndDate.DayNumber - StartDate.DayNumber;


    public static DateRange Create(DateOnly start, DateOnly end)
    {
        if (start > end)
        {
            throw new ApplicationException("End date precedes start date");
        }

        return new DateRange
        {
            StartDate = start,
            EndDate = end,
        };
    }
}