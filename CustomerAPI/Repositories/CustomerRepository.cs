using Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly ApplicationDbContext _context;

    public CustomerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IQueryable<Customer> GetAllAsync()
    {
        return _context.Customers;
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.FindAsync(id);
    }

    public async Task CreateAsync(Customer customer)
    {
        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task BulkCreateAsync(List<Customer> consumers)
    {
        _context.Customers.AddRange(consumers);
        await _context.SaveChangesAsync();
    }
}
