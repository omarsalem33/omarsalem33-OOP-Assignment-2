namespace SRP.Models;

public sealed class CheckoutPricingCalculator
{
    public decimal SubTotal(IReadOnlyList<(string Sku, decimal Price, int Qty)> lines)
        => lines.Sum(l => l.Price * l.Qty);

    public decimal GrandTotal(decimal subtotal, decimal discount, bool giftWrap)
    {
        var total = subtotal - discount;
        if (giftWrap) total += 4.99m;
        return Math.Max(0m, total);
    }
}