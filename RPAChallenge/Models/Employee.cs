namespace RPAChallenge.Models;

public class Employee
{
    private string FirstName { get; }
    private string LastName { get; }
    private string CompanyName { get; }
    private string RoleInCompany { get; }
    private string Address { get; }
    private string Email { get; }
    private int PhoneNumber { get; }

    public Employee(string firstName, string lastName, string companyName,
        string roleInCompany, string address, string email, int phoneNumber)
    {
        FirstName = firstName;
        LastName = lastName;
        CompanyName = companyName;
        RoleInCompany = roleInCompany;
        Address = address;
        Email = email;
        PhoneNumber = phoneNumber;
    }

    public string GetFirstName()
    {
        return FirstName;
    }

    public string GetLastName()
    {
        return LastName;
    }

    public string GetCompanyName()
    {
        return CompanyName;
    }

    public string GetRoleInCompany()
    {
        return RoleInCompany;
    }

    public string GetAddress()
    {
        return Address;
    }

    public string GetEmail()
    {
        return Email;
    }

    public int GetPhoneNumber()
    {
        return PhoneNumber;
    }
}