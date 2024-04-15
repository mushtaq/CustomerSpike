
using FileHelpers;

namespace  DTO;

[FixedLengthRecord]
public class Customer
{
    [FieldFixedLength(6)]
    public int Id { get; set; }
    
    [FieldFixedLength(10)]
    public string FirstName { get; set; }
    
    [FieldFixedLength(10)]
    public string LastName { get; set; }
    
    [FieldFixedLength(6)]
    public int EscoId { get; set; }
}