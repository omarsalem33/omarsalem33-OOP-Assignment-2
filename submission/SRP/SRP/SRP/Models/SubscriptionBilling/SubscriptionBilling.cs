namespace SRP.Models.SubscriptionBilling;

public sealed class SubscriptionBilling
{
    private readonly SubscriptionProrationCalculator _proration = new();
    private readonly InvoiceNumberGenerator _invoiceNumbers = new();
    private readonly FailedPaymentTracker _failures = new();
    private readonly DunningEmailFormatter _dunning = new();
    private readonly LedgerJournalLineFormatter _ledger = new();

    public string CustomerId { get; }
    public decimal MonthlyPrice { get; }
    public DateOnly PeriodStart { get; }
    public DateOnly PeriodEnd { get; }
    public int FailedPayments => _failures.Count;

    public SubscriptionBilling(string customerId, decimal monthlyPrice, DateOnly periodStart, DateOnly periodEnd)
    {
        CustomerId = customerId;
        MonthlyPrice = monthlyPrice;
        PeriodStart = periodStart;
        PeriodEnd = periodEnd;
    }

    public decimal Prorate(DateOnly activeFrom) => _proration.Calculate(MonthlyPrice, PeriodStart, PeriodEnd, activeFrom);
    public string NextInvoiceNumber() => _invoiceNumbers.Next(PeriodStart);
    public void RegisterFailedPayment() => _failures.RegisterFailure();

    public string DunningEmail(string customerName, DateOnly asOf)
    {
        var amount = Prorate(PeriodStart);
        var invoice = NextInvoiceNumber();
        return _dunning.Format(customerName, asOf, amount, invoice, FailedPayments);
    }

    public string LedgerJournalLine(DateOnly activeFrom)
        => _ledger.Format(CustomerId, NextInvoiceNumber(), Prorate(activeFrom));
}