namespace SRP.Models.AppointmentDesk;

public sealed class AppointmentSmsReminderFormatter
{
    public string Format(DateTimeOffset slot, string clinicPhone)
        => $"Reminder: appointment {slot:MMM dd HH:mm}. Call {clinicPhone} to reschedule.";
}