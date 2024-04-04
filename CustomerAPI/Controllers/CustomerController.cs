
using Entities;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Controller;

[ApiController]
[Route("api/customers")]
public class ConsumersController(ICustomerRepository customerRepository) : ControllerBase
{
    [HttpGet]
    public IQueryable<Customer> GetAll()
    {
        return customerRepository.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var consumer = await customerRepository.GetByIdAsync(id);
        if (consumer == null)
        {
            return NotFound();
        }
        return Ok(consumer);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Customer customer)
    {
        await customerRepository.CreateAsync(customer);
        return CreatedAtAction(nameof(GetById), new { id = customer.Id }, customer);
    }

    [HttpPost("bulk")]
    public async Task<IActionResult> BulkCreate([FromBody] List<Customer> consumers)
    {
        await customerRepository.BulkCreateAsync(consumers);
        return Ok();
    }
}
