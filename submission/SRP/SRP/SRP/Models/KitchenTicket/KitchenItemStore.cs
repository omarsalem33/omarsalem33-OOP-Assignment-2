namespace SRP.Models.KitchenTicket;

public sealed class KitchenItemStore
{
    private readonly List<(string Item, List<string> Ingredients, int PrepMinutes)> _items = new();

    public void Add(string item, IEnumerable<string> ingredients, int prepMinutes)
        => _items.Add((item, ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList(), prepMinutes));

    public IReadOnlyList<(string Item, List<string> Ingredients, int PrepMinutes)> Items => _items;
}