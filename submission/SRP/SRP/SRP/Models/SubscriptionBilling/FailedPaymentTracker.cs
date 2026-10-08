namespace SRP.Models.SubscriptionBilling;

public sealed class FailedPaymentTracker
{
    public int Count { get; private set; }
    public void RegisterFailure() => Count++;
}