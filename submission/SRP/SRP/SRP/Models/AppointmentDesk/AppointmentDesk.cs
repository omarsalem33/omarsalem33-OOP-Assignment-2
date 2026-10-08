namespace SRP.Models.AppointmentDesk;

public sealed class AppointmentDesk
{
    private readonly AppointmentHoursPolicy _hours;
    private readonly AppointmentBookingCalendar _calendar = new();
    private readonly AppointmentSlotFinder _finder;
    private readonly AppointmentBooker _booker;
    private readonly IcsAppointmentFormatter _ics;
    private readonly AppointmentSmsReminderFormatter _sms = new();

    public TimeOnly Open => _hours.Open;
    public TimeOnly Close => _hours.Close;
    public int SlotMinutes => _hours.SlotMinutes;

    public AppointmentDesk(TimeOnly open, TimeOnly close, int slotMinutes)
    {
        _hours = new AppointmentHoursPolicy(open, close, slotMinutes);
        _finder = new AppointmentSlotFinder(_hours, _calendar);
        _booker = new AppointmentBooker(_hours, _calendar);
        _ics = new IcsAppointmentFormatter(slotMinutes);
    }

    public bool IsWithinBusinessHours(DateTimeOffset when) => _hours.IsWithinBusinessHours(when);
    public DateTimeOffset? FindNextSlot(DateTimeOffset from, int searchHours) => _finder.Find(from, searchHours);
    public bool TryBook(DateTimeOffset slot) => _booker.TryBook(slot);
    public string ToIcs(DateTimeOffset slot, string patientName, string clinician) => _ics.Format(slot, patientName, clinician);
    public string SmsReminder(DateTimeOffset slot, string clinicPhone) => _sms.Format(slot, clinicPhone);
}