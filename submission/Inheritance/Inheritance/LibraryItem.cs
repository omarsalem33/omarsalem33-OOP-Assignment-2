namespace Inheritance;

public class LibraryItem
{
    public string CatalogNumber { get; set; }
    public string Title { get; set; }
    public decimal BaseLateFee { get; set; }
    public int LoanDays { get; set; }
    public decimal LateFeeMultiplier { get; set; }
    
    public decimal DailyLateFee => BaseLateFee * LateFeeMultiplier;

    public bool IsWithdrawn { get; set; }
    public bool IsOnLoan { get; set; }

    public LibraryItem(string catalogNumber, string title, decimal baseLateFee, int loanPeriodDays, decimal lateFeeMultiplier)
    {
        if(baseLateFee <= 0)
            throw new ArgumentException("BaseLateFee must be greater than zero.");
        CatalogNumber = catalogNumber;
        Title = title;
        BaseLateFee = baseLateFee;
        LoanDays = loanPeriodDays;
        LateFeeMultiplier = lateFeeMultiplier;
    }

    public void SetBaseLateFee(decimal newFee)
    {
        if(newFee <= 0)
            throw new ArgumentException("BaseLateFee must be greater than zero.");
        BaseLateFee = newFee;
    }
    public void Withdraw() => IsWithdrawn = true;
    public void Restore() => IsWithdrawn = false;
    
}