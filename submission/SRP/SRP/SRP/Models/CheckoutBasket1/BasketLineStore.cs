namespace SRP.Models.CheckoutBasket1;

public sealed class BasketLineStore
{
    private readonly List<(string Sku, decimal Price, int Qty)> _lines = new();
    public void Add(string sku, decimal price, int qty) => _lines.Add((sku, price, qty));
    public IReadOnlyList<(string Sku, decimal Price, int Qty)> Lines => _lines;
}