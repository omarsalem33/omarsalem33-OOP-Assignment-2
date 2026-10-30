namespace SRP.Models.LoanDesk;

public sealed class LoanEligibilityPolicy
{
    public bool IsEligible(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral, LoanRiskScorer scorer)
        => scorer.Score(requestedAmount, creditScore, employmentMonths, hasCollateral) >= 55m && creditScore >= 580;
}