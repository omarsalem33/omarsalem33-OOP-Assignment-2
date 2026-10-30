namespace SRP.Models.LoanDesk;

public sealed class LoanUnderwriterCsvFormatter
{
    public string Format(string applicationId, int creditScore, int employmentMonths, bool hasCollateral, decimal risk, bool eligible)
        => $"{applicationId},{creditScore},{employmentMonths},{(hasCollateral ? 1 : 0)},{risk:0.00},{(eligible ? "Y" : "N")}";
}