using Entities;

namespace CustomerAPI.Repositories;

public interface ICustomerRepository
{
    IQueryable<Customer> GetAllAsync();
    Task<Customer> GetByIdAsync(int id);
    Task CreateAsync(Customer customer);
    Task BulkCreateAsync(List<Customer> consumers);
}
