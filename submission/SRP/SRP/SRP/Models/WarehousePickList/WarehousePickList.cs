namespace SRP.Models.WarehousePickList;


public sealed class WarehousePickList
{
    private readonly PickNeedStore _lines = new();
    private readonly StockAllocationPolicy _allocation = new();
    private readonly WarehouseWalkingOrderPlanner _walking = new();
    private readonly PickerInstructionFormatter _picker = new();
    private readonly WmsXmlBatchFormatter _xml = new();

    public void AddNeed(string sku, string aisle, int bin, int qtyNeeded, int qtyOnHand)
        => _lines.Add(sku, aisle, bin, qtyNeeded, qtyOnHand);

    public IReadOnlyList<(string Sku, int Allocated)> Allocate() => _allocation.Allocate(_lines.Lines);
    public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> WalkingOrder() => _walking.Plan(_lines.Lines);
    public string PickerScript() => _picker.Format(_lines.Lines, Allocate(), WalkingOrder());
    public string WmsXmlBatch(string batchId) => _xml.Format(batchId, Allocate());
}