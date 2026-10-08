namespace SRP.Models;

public sealed class WardPagerCodePolicy
{
    public string? GetCode(int bed, int acuity)
        => acuity >= 8 ? $"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}" : null;
}