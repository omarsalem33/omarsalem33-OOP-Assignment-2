namespace SRP.Models.SubscriptionBilling;

public sealed class LedgerJournalLineFormatter
{
    public string Format(string customerId, string invoice, decimal amount)
        => $"{customerId},{invoice},{amount:0.00},AR-SUB";
}