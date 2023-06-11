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
    private readonly string _url;
    private readonly IWebDriver _driver;
    private List<Employee> _employees;
    private readonly List<string> _fieldsToFill;
    /// <summary>
    /// Единственные вшитые данные, количество раундов на RPA
    /// </summary>
    private readonly int _numberOfRounds = 10;

    public SeleniumScript(string url, Browser browser, List<Employee> employees, List<string> fieldsToFill)
    {
        _url = url;
        _employees = new List<Employee>(employees);
        _fieldsToFill = new List<string>(fieldsToFill);

        this._driver = browser switch
        {
            Browser.Firefox => new FirefoxDriver(),
            Browser.Chrome => new ChromeDriver(),
            Browser.Edge => new EdgeDriver(),
            _ => new EdgeDriver()
        };
    }

    private void FillField(string fieldName, string inputData, IList<IWebElement> inputs)
    {
        foreach (IWebElement input in inputs)
        {
            if (input.GetAttribute("outerHTML").Contains(fieldName))
            {
                input.SendKeys(inputData);
                return;
            }
        }
    }

    private void FillForm(Employee employee)
    {
        IList<IWebElement> inputs = _driver.FindElements(By.TagName("input"));
        List<string> strEmployee = employee.MakeList();

        for (int i = 0; i < _fieldsToFill.Count; i++)
        {
            FillField(_fieldsToFill[i], strEmployee[i], inputs);
        }

        _driver.FindElement(By.CssSelector("input.btn")).Click();
    }

    public void FillForms()
    {
        _driver.FindElement(By.XPath("button.waves-effect")).Click();
        
        for (var i = 0; i < _numberOfRounds; i++)
        {
            FillForm(_employees[i]);
        }
    }
}