namespace SRP.Models.LoanDesk;

public sealed class LoanDesk
{
    private readonly LoanRiskScorer _risk = new();
    private readonly LoanEligibilityPolicy _eligibility = new();
    private readonly LoanDocumentPolicy _documents = new();
    private readonly LoanDecisionLetterFormatter _letter = new();
    private readonly LoanUnderwriterCsvFormatter _csv = new();

    public decimal RequestedAmount { get; }
    public int CreditScore { get; }
    public int EmploymentMonths { get; }
    public bool HasCollateral { get; }

    public LoanDesk(decimal requestedAmount, int creditScore, int employmentMonths, bool hasCollateral)
    {
        RequestedAmount = requestedAmount;
        CreditScore = creditScore;
        EmploymentMonths = employmentMonths;
        HasCollateral = hasCollateral;
    }

    public decimal RiskScore() => _risk.Score(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral);
    public bool IsEligible() => _eligibility.IsEligible(RequestedAmount, CreditScore, EmploymentMonths, HasCollateral, _risk);
    public IReadOnlyList<string> RequiredDocuments()
        => _documents.Required(RequestedAmount, EmploymentMonths, HasCollateral, IsEligible());
    public string DecisionLetter(string applicantName)
        => _letter.Format(applicantName, RequestedAmount, RiskScore(), IsEligible(), RequiredDocuments());
    public string UnderwriterCsvRow(string applicationId)
        => _csv.Format(applicationId, CreditScore, EmploymentMonths, HasCollateral, RiskScore(), IsEligible());
}