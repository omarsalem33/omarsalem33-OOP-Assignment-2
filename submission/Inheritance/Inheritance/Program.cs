namespace Inheritance;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== TESTING CITY LIBRARY SYSTEM ===\n");

        var student = new StudentMember("STU-1", "Ahmad", "0100000000");
        var dvd = new DVD("D1", "Inception", 5.0m);

        var loan1 = student.BorrowItem(dvd, DateTime.Now);

        try
        {
            var student2 = new StudentMember("STU-2", "Ali", "0110000000");
            student2.BorrowItem(dvd, DateTime.Now);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Expected Error]: {ex.Message}");
        }

        var premium = new PremiumMember("PREM-1", "Mona", "0120000000", discountPercentage: 20m);
        var book = new Book("B1", "C# in Depth", 2.0m);

        DateTime borrowDate = new DateTime(2026, 10, 1);
        var pLoan = premium.BorrowItem(book, borrowDate);

        premium.ReturnItem(pLoan, borrowDate.AddDays(26));

        Console.WriteLine($"\nItem: {book.Title}");
        Console.WriteLine($"Due Date: {pLoan.DueDate:yyyy-MM-dd}");
        Console.WriteLine($"Return Date: {pLoan.ReturnDate:yyyy-MM-dd}");
        Console.WriteLine($"Days Late: {pLoan.DaysLate}");
        Console.WriteLine($"Late Fee: ${pLoan.LateFee} (After 20% discount)");
        Console.WriteLine($"Premium Points: {premium.ReadingPoints}");
    }
}