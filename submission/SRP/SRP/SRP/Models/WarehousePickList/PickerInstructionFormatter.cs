namespace SRP.Models.WarehousePickList;


public sealed class PickerInstructionFormatter
{
    public string Format(
        IReadOnlyList<(string Sku, string Aisle, int Bin, int QtyNeeded, int QtyOnHand)> lines,
        IReadOnlyList<(string Sku, int Allocated)> allocations,
        IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> walkingOrder)
    {
        var steps = walkingOrder
            .Select((s, i) => $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");
        var shortfalls = allocations.Where(a =>
        {
            var need = lines.First(l => l.Sku == a.Sku).QtyNeeded;
            return a.Allocated < need;
        });
        var warn = shortfalls.Any()
            ? "SHORTAGES: " + string.Join(", ", shortfalls.Select(s => s.Sku))
            : "SHORTAGES: none";
        return string.Join('\n', steps) + "\n" + warn;
    }
}