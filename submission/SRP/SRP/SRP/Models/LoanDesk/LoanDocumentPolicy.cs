namespace SRP.Models.LoanDesk;

public sealed class LoanDocumentPolicy
{
    public IReadOnlyList<string> Required(decimal requestedAmount, int employmentMonths, bool hasCollateral, bool eligible)
    {
        var docs = new List<string> { "National ID", "Proof of income (3 months)" };
        if (requestedAmount > 40_000m) docs.Add("Bank statements (6 months)");
        if (hasCollateral) docs.Add("Collateral ownership deed");
        if (employmentMonths < 12) docs.Add("Employer letter");
        if (!eligible) docs.Add("Manual underwriter referral form");
        return docs;
    }
}