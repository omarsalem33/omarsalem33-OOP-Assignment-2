namespace SRP.Models.AppointmentDesk;

public sealed class AppointmentBookingCalendar
{
    private readonly HashSet<DateTimeOffset> _booked = new();
    public bool Contains(DateTimeOffset slot) => _booked.Contains(slot);
    public bool Book(DateTimeOffset slot) => _booked.Add(slot);
}