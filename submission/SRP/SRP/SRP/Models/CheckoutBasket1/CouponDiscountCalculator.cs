namespace SRP.Models;

public sealed class CouponDiscountCalculator
{
    public decimal Calculate(string? rawCoupon, decimal subtotal)
    {
        if (string.IsNullOrWhiteSpace(rawCoupon)) return 0m;
        var t = rawCoupon.Trim().ToUpperInvariant();
        if (t.StartsWith("SAVE") && int.TryParse(t[4..], out var pct) && pct is > 0 and <= 50)
            return Math.Round(subtotal * pct / 100m, 2);
        if (t.Contains("FREESHIP")) return 0m;
        if (t == "WELCOME10") return Math.Min(10m, subtotal);
        return 0m;
    }
}