using CsvHelper.Configuration.Attributes;

namespace RPAChallenge.Models;

public class Employee
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CompanyName { get; set; }
    public string RoleInCompany { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public void PrintEmployee()
    {
        Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}", FirstName, LastName, CompanyName,
        RoleInCompany, Address, Email, PhoneNumber);
    }

    public List<string> MakeList()
    {
        return new List<string>
        {
            FirstName, LastName, CompanyName, RoleInCompany, Address, Email, PhoneNumber
        };
    }

}