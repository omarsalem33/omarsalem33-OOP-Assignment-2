namespace Inheritance;

public class HeadLibrarian: Staff
{
    public decimal ResponsibilityAllowance { get; } = 400m;
    public override decimal MonthlyPay => MonthlySalary + ResponsibilityAllowance;

    public HeadLibrarian(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary)
        : base(personId, fullName, phone, hireDate, monthlySalary)
    {
    }
}