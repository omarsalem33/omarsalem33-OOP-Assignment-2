namespace SRP.Models.SupportTicket;

public sealed class SupportEscalationFormatter
{
    public string Format(string id, string priority, DateTimeOffset deadline)
        => $"ESCALATE {id} priority={priority} breachAt={deadline:u} keywords-scanned=yes";
}