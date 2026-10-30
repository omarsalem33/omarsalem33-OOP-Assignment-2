namespace Inheritance;

public class Loan
{
    public string LoanId { get; }
    public DateTime BorrowDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public Member Member { get; }
    public LibraryItem Item { get; }
    public LoanStatus Status { get; private set; }

    public DateTime DueDate => BorrowDate.AddDays(Item.LoanDays);

    public int DaysLate
    {
        get
        {
            if (!ReturnDate.HasValue || ReturnDate.Value <= DueDate)
                return 0;
            return (ReturnDate.Value.Date - DueDate.Date).Days;
        }
    }
    
    public decimal LateFee
    {
        get
        {
            if (DaysLate <= 0) return 0m;
            decimal baseFee = DaysLate * Item.DailyLateFee;
            decimal discount = baseFee * (Member.FeeDiscountPercentage / 100m);
            return Math.Max(0m, baseFee - discount);
        }
    }
    public Loan(string loanId, Member member, LibraryItem item, DateTime borrowDate)
    {
        LoanId = loanId;
        Member = member;
        Item = item;
        BorrowDate = borrowDate;
        Status = LoanStatus.Borrowed;
    }
    public void RecordReturn(DateTime returnDate)
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException($"Cannot return a loan with status '{Status}'.");
        if (returnDate < BorrowDate)
            throw new ArgumentException("Return date cannot be before borrow date.");

        ReturnDate = returnDate;
        Status = LoanStatus.Returned;
    }
    public void MarkAsLost()
    {
        if (Status != LoanStatus.Borrowed)
            throw new InvalidOperationException($"Cannot mark a loan with status '{Status}' as lost.");
        Status = LoanStatus.Lost;
    }
}