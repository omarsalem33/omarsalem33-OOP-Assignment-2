namespace SRP.Models.KitchenTicket;

public sealed class ExpoLanePolicy
{
    public string Get(IReadOnlyList<string> allergens, int readyMinutes)
        => allergens.Count > 0 ? "LANE-ALLERGY" : readyMinutes > 20 ? "LANE-SLOW" : "LANE-FAST";
}