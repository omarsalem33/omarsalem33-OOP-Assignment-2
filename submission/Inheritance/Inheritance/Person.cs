namespace Inheritance;

public abstract class Person
{
    public string PersonId {get;}
    public string FullName {get;}
    public string Phone { get; }

    protected Person(string personId, string fullName, string phone)
    {
        if (string.IsNullOrEmpty(personId))
        {
            throw new ArgumentException("Person id cannot be null or empty");
        }

        if (string.IsNullOrEmpty(fullName))
        {
            throw new ArgumentException("Person full name cannot be null or empty");
        }
        if (string.IsNullOrEmpty(phone)){
            throw new ArgumentException("Person phone cannot be null or empty");
        }
        
        PersonId = personId;
        FullName = fullName;
        Phone = phone;
    }
}