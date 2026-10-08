namespace Inheritance;

public class Librarian : Staff
{
    public Librarian(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary) 
        : base(personId, fullName, phone, hireDate, monthlySalary) { }
}