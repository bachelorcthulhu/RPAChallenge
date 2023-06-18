using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;

namespace RPAChallenge.Models;

public static class readCSV
{
    public static List<Employee> ReadData(string filePath)
    {
        List<Employee> employees = new List<Employee>();
        
        var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true,
        };

        using var reader = new StreamReader(filePath);
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
        
        var records = csv.GetRecords<Employee>();
        employees.AddRange(records);

        return employees;
    }
}