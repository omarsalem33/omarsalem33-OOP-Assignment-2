namespace SRP.Models;

public sealed class HonorRollPolicy
{
    public bool Qualifies(decimal average, string letter) => average >= 85 && (letter is "A" or "B");
}
