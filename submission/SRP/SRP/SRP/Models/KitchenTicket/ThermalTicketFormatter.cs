namespace SRP.Models.KitchenTicket;

public sealed class ThermalTicketFormatter
{
    private readonly AllergenDetector _allergens;
    private readonly KitchenReadyTimeEstimator _eta;

    public ThermalTicketFormatter(AllergenDetector allergens, KitchenReadyTimeEstimator eta)
    {
        _allergens = allergens;
        _eta = eta;
    }

    public string Format(IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> items, int orderNumber)
    {
        var width = 32;
        var line = new string('=', width);
        var body = string.Join('\n', items.Select(i => $"* {i.Item.ToUpperInvariant()} ({i.PrepMinutes}m)"));
        var allergens = _allergens.Detect(items);
        var allergyLine = allergens.Count == 0 ? "ALLERGENS: none" : "ALLERGENS: " + string.Join(",", allergens);
        return $"{line}\nORDER #{orderNumber}\nETA {_eta.Estimate(items, 2)} MIN\n{body}\n{allergyLine}\n{line}\n";
    }
}