namespace Inheritance;

public abstract class Staff: Person
{
    public DateTime HireDate { get;  }
    public decimal MonthlySalary { get; private set;  }
    
    public virtual decimal MonthlyPay => MonthlySalary;

    protected Staff(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary)
        : base(personId, fullName, phone)
    {
        if (monthlySalary <= 0) throw new ArgumentException("Salary must be positive.");
        HireDate = hireDate;
        MonthlySalary = monthlySalary;
    }

    public void GiveRaise(decimal percentage)
    {
        if (percentage <= 0)
            throw new ArgumentException("Percentage must be positive.");
        MonthlySalary += MonthlySalary * (percentage / 100m);
    }
    
}