namespace SRP.Models;

public sealed class GiftMessageFormatter
{
    public string Format(IReadOnlyList<(string Sku, decimal Price, int Qty)> lines, string fromName, decimal grandTotal)
    {
        var items = string.Join(", ", lines.Select(l => l.Sku));
        return $"Dear friend,\nA gift from {fromName} awaits ({items}).\nTotal surprise value: {grandTotal:C}\n";
    }
}