namespace SRP.Models.SubscriptionBilling;

public sealed class InvoiceNumberGenerator
{
    private static int _sequence = 1000;
    public string Next(DateOnly periodStart)
    {
        var n = ++_sequence;
        return $"INV-{periodStart:yyyyMM}-{n:D5}";
    }
}