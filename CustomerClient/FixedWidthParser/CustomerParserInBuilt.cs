using DTO;
using Microsoft.VisualBasic.FileIO;

namespace CustomerClient.FixedWidthParser;

public static class CustomerParserInBuilt
{
    public static List<Customer> Parse(string filePath)
    {
        using var parser = new TextFieldParser(filePath);
        parser.TextFieldType = FieldType.FixedWidth;
        parser.SetFieldWidths([6, 10, 10, 6]);
        
        List<Customer> customers = [];
        while (!parser.EndOfData)
        {
            var fields = parser.ReadFields();
            customers.Add(new Customer
            {
                Id = int.Parse(fields[0]),
                FirstName = fields[1],
                LastName = fields[2],
                EscoId = int.Parse(fields[3])
            });
        }

        return customers;
    }
}