namespace Inheritance;

public abstract class Member : Person
{
    private readonly List<Loan> _loans = new();

    public int MaxLoans { get; }
    public decimal FeeDiscountPercentage { get; }
    public int ReadingPoints { get; protected set; }

    public int ActiveLoanCount => _loans.Count(l => l.Status == LoanStatus.Borrowed);
    public IReadOnlyList<Loan> Loans => _loans.AsReadOnly();

    protected Member(string personId, string fullName, string phone, int maxLoans, decimal feeDiscountPercentage)
        : base(personId, fullName, phone)
    {
        MaxLoans = maxLoans;
        FeeDiscountPercentage = feeDiscountPercentage;
    }

    public Loan BorrowItem(LibraryItem item, DateTime borrowDate)
    {
        if (item.IsWithdrawn) throw new InvalidOperationException("Item is withdrawn.");
        if (item.IsOnLoan) throw new InvalidOperationException("Item is already on loan.");
        if (ActiveLoanCount >= MaxLoans) throw new InvalidOperationException($"Max loan limit ({MaxLoans}) reached.");

        var loan = new Loan(Guid.NewGuid().ToString("N")[..8], this, item, borrowDate);
        item.IsOnLoan = true;
        _loans.Add(loan);
        return loan;
    }

    public void ReturnItem(Loan loan, DateTime returnDate)
    {
        loan.RecordReturn(returnDate);
        loan.Item.IsOnLoan = false;

        if (this is PremiumMember)
        {
            ReadingPoints += 5;
        }
    }
}

public class StudentMember : Member
{
    public StudentMember(string personId, string fullName, string phone)
        : base(personId, fullName, phone, maxLoans: 3, feeDiscountPercentage: 0m) { }
}

public class PremiumMember : Member
{
    public PremiumMember(string personId, string fullName, string phone, decimal discountPercentage)
        : base(personId, fullName, phone, maxLoans: 10, feeDiscountPercentage: discountPercentage) { }
}