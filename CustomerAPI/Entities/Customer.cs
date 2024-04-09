using System.ComponentModel.DataAnnotations.Schema;

namespace  Entities;

public class Customer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int EscoId { get; set; }
}