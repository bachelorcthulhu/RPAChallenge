// See https://aka.ms/new-console-template for more information

using RPAChallenge.Models;

Console.WriteLine("Hello, World!");

List<string> fields = new List<string>
{
    "labelFirstName", "labelLastName","labelCompanyName","labelRole",
    "labelAddress", "labelEmail","labelPhone"
};

SeleniumScript RPAScript = new SeleniumScript("https://www.rpachallenge.com/", Browser.Firefox, fields);
RPAScript.FillForms();
Console.WriteLine();