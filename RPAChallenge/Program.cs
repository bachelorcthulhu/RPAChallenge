using RPAChallenge.Models;

List<Employee> employees = readCSV.ReadData("C://Users//bache//Downloads//challenge.csv");
List<List<string>> listOfEmployees = new List<List<string>>();

foreach (var employee in employees)
{
    employee.PrintEmployee();
}

foreach (var employee in employees)
{
    listOfEmployees.Add(employee.MakeList());
}

List<string> fields = new List<string>
{
    "labelFirstName", "labelLastName","labelCompanyName","labelRole",
    "labelAddress", "labelEmail","labelPhone"
};

SeleniumScript rpaScript = new SeleniumScript("https://www.rpachallenge.com/", Browser.Firefox, employees, fields);
rpaScript.FillForms();

Console.ReadLine();