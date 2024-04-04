using Entities;
using Microsoft.EntityFrameworkCore;
namespace  CustomerAPI;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
        
    }

    public DbSet<Esco> Escos { get; set; }
    public DbSet<Customer> Customers { get; set; }

  
}