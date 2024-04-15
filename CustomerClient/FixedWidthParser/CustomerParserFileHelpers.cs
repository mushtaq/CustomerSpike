using DTO;
using FileHelpers;

namespace CustomerClient.FixedWidthParser;

public static class CustomerParserFileHelpers
{
    public static List<Customer> Parse(string filePath)
    {
        var engine = new FileHelperEngine<Customer>();
        return engine.ReadFile(filePath).ToList();
    }
}