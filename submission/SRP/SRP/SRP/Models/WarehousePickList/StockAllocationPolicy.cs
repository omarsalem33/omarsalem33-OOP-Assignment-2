namespace SRP.Models.WarehousePickList;

public sealed class StockAllocationPolicy
{
    public IReadOnlyList<(string Sku, int Allocated)> Allocate(
        IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines)
        => lines.Select(l => (l.Sku, Math.Min(l.QtyNeeded, l.QtyOnHand))).ToList();
}