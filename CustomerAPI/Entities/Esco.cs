using System.ComponentModel.DataAnnotations.Schema;

namespace Entities;

public class Esco
{
    public int Id { get; set; }
    public string Name { get; set; }
    [NotMapped]
    public List<Customer> Customers { get; set; }
}

