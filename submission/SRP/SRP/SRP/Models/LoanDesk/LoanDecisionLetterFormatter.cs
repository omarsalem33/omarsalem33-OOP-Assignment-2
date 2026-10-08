namespace SRP.Models.LoanDesk;

public sealed class LoanDecisionLetterFormatter
{
    public string Format(string applicantName, decimal requestedAmount, decimal risk, bool eligible, IReadOnlyList<string> documents)
    {
        if (eligible)
            return $"Dear {applicantName},\nYour request for {requestedAmount:C} is pre-approved (risk {risk:0}).\n" +
                   $"Please upload: {string.Join("; ", documents)}.\n";
        return $"Dear {applicantName},\nWe are unable to approve {requestedAmount:C} at this time.\n" +
               $"Reference risk={risk:0}. You may reapply after improving documentation.\n";
    }
}