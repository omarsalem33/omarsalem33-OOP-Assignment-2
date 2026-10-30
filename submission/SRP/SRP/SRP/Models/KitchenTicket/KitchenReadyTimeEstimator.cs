namespace SRP.Models.KitchenTicket;


public sealed class KitchenReadyTimeEstimator
{
    private readonly AllergenDetector _allergens;

    public KitchenReadyTimeEstimator(AllergenDetector allergens) => _allergens = allergens;

    public int Estimate(IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> items, int openStations)
    {
        if (openStations <= 0) openStations = 1;
        var sequential = items.Sum(i => i.PrepMinutes);
        var parallel = (int)Math.Ceiling(sequential / (double)openStations);
        if (_allergens.Detect(items).Count > 0) parallel += 3;
        var longest = items.Count == 0 ? 0 : items.Max(i => i.PrepMinutes);
        return Math.Max(parallel, longest);
    }
}