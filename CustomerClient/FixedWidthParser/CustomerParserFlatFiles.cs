using DTO;
using FlatFiles.TypeMapping;

namespace CustomerClient.FixedWidthParser;

public static class CustomerParserFlatFiles
{
    public static List<Customer> Parse(string filePath)
    {
        var mapper = FixedLengthTypeMapper.Define<Customer>();
        mapper.Property(c => c.Id, 6);
        mapper.Property(c => c.FirstName, 10);
        mapper.Property(c => c.LastName, 10);
        mapper.Property(c => c.EscoId, 6);

        return mapper.Read(new StreamReader(filePath)).ToList();
    }
}