using System.Text; 
using RPAChallenge.Models;

Console.OutputEncoding = Encoding.UTF8; //Добавлено, чтобы русская локаль всегда отображалась

List<string> fields = new List<string>
{
    "labelFirstName", "labelLastName","labelCompanyName","labelRole",
    "labelAddress", "labelEmail","labelPhone"
};

List<Employee> employees;

while (true)
{
    Console.WriteLine("Введите путь до csv файла");
    var dirPath = @"" + Console.ReadLine();

    if (File.Exists(dirPath))
    {
        try
        {
            employees = readCSV.ReadData(dirPath);
            break;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}

foreach (var employee in employees)
{
    employee.PrintEmployee();
}

Console.WriteLine("Браузер по умолчанию - Microsoft Edge");
Console.WriteLine("Напишите f - чтобы выбрать Firefox, c - чтобы выбрать Chrome");
Console.WriteLine("Или любой другой символ, чтобы оставить Microsoft Edge");
Console.WriteLine();

var input = Console.ReadLine();

/// Теоретически можно создать один экземлпяр SeleniumScript
/// SeleniumScript rpaScript = new SeleniumScript("https://www.rpachallenge.com/", Browser.Edge, employees, fields);
/// А потом менять его с помощью метода ChangeDriver()
/// Но в таком случае при создании экземпляра всегда будет открываться Edge
/// А при ChangeDriver() будет дополнительно открываться Chrome, Firefox - или будет переход на RPA сайт, если выбран Edge

switch (input)
{
    case "f":
        SeleniumScript rpaScriptFirefox = new SeleniumScript("https://www.rpachallenge.com/", Browser.Firefox, employees, fields);
        rpaScriptFirefox.OpenSite();
        rpaScriptFirefox.FillForms();
        break;
    case "c":
        SeleniumScript rpaScriptChrome= new SeleniumScript("https://www.rpachallenge.com/", Browser.Edge, employees, fields);
        rpaScriptChrome.OpenSite();
        rpaScriptChrome.FillForms();
        break;
    default:
        SeleniumScript rpaScriptEdge = new SeleniumScript("https://www.rpachallenge.com/", Browser.Edge, employees, fields);
        rpaScriptEdge.OpenSite();
        rpaScriptEdge.FillForms();
        break;
}

Console.WriteLine("Нажмите любую кнопку чтобы выйти из программы...");
Console.ReadKey();