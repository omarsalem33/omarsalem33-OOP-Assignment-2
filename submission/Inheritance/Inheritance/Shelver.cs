namespace Inheritance;

public class Shelver : Staff
{
    public string Section { get; private set; }
    
    public Shelver(string personId, string fullName, string phone, DateTime hireDate, decimal monthlySalary, string section) 
        : base(personId, fullName, phone, hireDate, monthlySalary)
    {
        Section = section;
    }
    
    public void Reassign(string newsection)
    {
        if(string.IsNullOrEmpty(Section))
            throw new ArgumentException("Section cannot be null or empty.");
        Section = newsection;
    }
}