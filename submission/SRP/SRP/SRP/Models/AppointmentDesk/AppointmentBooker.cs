namespace SRP.Models.AppointmentDesk;

public sealed class AppointmentBooker
{
    private readonly AppointmentHoursPolicy _hours;
    private readonly AppointmentBookingCalendar _calendar;
    public AppointmentBooker(AppointmentHoursPolicy hours, AppointmentBookingCalendar calendar)
    {
        _hours = hours;
        _calendar = calendar;
    }
    public bool TryBook(DateTimeOffset slot)
        => _hours.IsWithinBusinessHours(slot) && _calendar.Book(slot);
}