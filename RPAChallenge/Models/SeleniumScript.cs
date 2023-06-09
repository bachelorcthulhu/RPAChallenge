using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace RPAChallenge.Models;

public enum Browser
{
    Firefox,
    Chrome,
    Edge
}

public class SeleniumScript
{
    private string Url { get; }
    private IWebDriver Driver { get; }
    private List<Employee> Employees { get; }

    public SeleniumScript(string url, Browser browser, List<Employee> employees)
    {
        Url = url;
        Employees = new List<Employee>(employees);

        switch (browser)
        {
            case Browser.Firefox:
                this.Driver = new FirefoxDriver();
                break;
            case Browser.Chrome:
                this.Driver = new ChromeDriver();
                break;
            case Browser.Edge:
                this.Driver = new EdgeDriver();
                break;
            default:
                this.Driver = new EdgeDriver();
                break;
        }
    }

    public void FillForm()
    {
        
    }
}