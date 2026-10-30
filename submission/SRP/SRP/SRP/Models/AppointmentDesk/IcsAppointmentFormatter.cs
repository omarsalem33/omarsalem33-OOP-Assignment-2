namespace SRP.Models.AppointmentDesk;

public sealed class IcsAppointmentFormatter
{
    private readonly int _slotMinutes;
    public IcsAppointmentFormatter(int slotMinutes) => _slotMinutes = slotMinutes;
    public string Format(DateTimeOffset slot, string patientName, string clinician)
    {
        var uid = Guid.NewGuid();
        var end = slot.AddMinutes(_slotMinutes);
        return "BEGIN:VCALENDAR\nVERSION:2.0\nBEGIN:VEVENT\n" +
               $"UID:{uid}\nDTSTART:{slot:yyyyMMdd'T'HHmmss'Z'}\nDTEND:{end:yyyyMMdd'T'HHmmss'Z'}\n" +
               $"SUMMARY:Visit {patientName} / {clinician}\nEND:VEVENT\nEND:VCALENDAR\n";
    }
}