namespace SRP.Models.AppointmentDesk;


public sealed class AppointmentSlotFinder
{
    private readonly AppointmentHoursPolicy _hours;
    private readonly AppointmentBookingCalendar _calendar;

    public AppointmentSlotFinder(AppointmentHoursPolicy hours, AppointmentBookingCalendar calendar)
    {
        _hours = hours;
        _calendar = calendar;
    }

    public DateTimeOffset? Find(DateTimeOffset from, int searchHours)
    {
        var cursor = _hours.Align(from);
        var end = from.AddHours(searchHours);
        while (cursor < end)
        {
            if (_hours.IsWithinBusinessHours(cursor) && !_calendar.Contains(cursor)) return cursor;
            cursor = cursor.AddMinutes(_hours.SlotMinutes);
        }
        return null;
    }
}