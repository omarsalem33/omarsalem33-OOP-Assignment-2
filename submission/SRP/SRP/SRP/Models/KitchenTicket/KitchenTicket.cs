namespace SRP.Models.KitchenTicket;

public sealed class KitchenTicket
{
    private readonly KitchenItemStore _items = new();
    private readonly AllergenDetector _allergens = new();
    private readonly KitchenReadyTimeEstimator _eta;
    private readonly ThermalTicketFormatter _thermal;
    private readonly ExpoLanePolicy _lane = new();

    public KitchenTicket()
    {
        _eta = new KitchenReadyTimeEstimator(_allergens);
        _thermal = new ThermalTicketFormatter(_allergens, _eta);
    }

    public void AddItem(string item, IEnumerable<string> ingredients, int prepMinutes)
        => _items.Add(item, ingredients, prepMinutes);
    public IReadOnlyList<string> DetectAllergens() => _allergens.Detect(_items.Items);
    public int EstimatedReadyMinutes(int openStations) => _eta.Estimate(_items.Items, openStations);
    public string RenderThermalTicket(int orderNumber) => _thermal.Format(_items.Items, orderNumber);
    public string ExpoLaneHint() => _lane.Get(DetectAllergens(), EstimatedReadyMinutes(2));
}