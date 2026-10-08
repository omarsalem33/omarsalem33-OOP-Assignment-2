namespace SRP.Models.WarehousePickList;

public sealed class PickNeedStore
{
    private readonly List<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> _lines = new();
    public void Add(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        => _lines.Add((sku, aisle, bin, qtyNeeded, qtyOnHand));
    public IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> Lines => _lines;
}