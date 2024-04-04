// See https://aka.ms/new-console-template for more information

using CustomerAPI;
using Entities;
using Microsoft.EntityFrameworkCore;

var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
var dbPath = @"/Users/mushtaq/projects/dotnet/CustomerSpike/CustomerAPI/Data/customerData.db";

var isExists = File.Exists(dbPath);

optionsBuilder.UseSqlite($"Data Source={dbPath}");
using var context = new ApplicationDbContext(optionsBuilder.Options);

var filePath = "CustomerData.txt";
var lines = File.ReadAllLines(filePath);

foreach (var line in lines)
{
    var parts = line.Split('\t').Select(p => p.Trim('~')).ToArray();

    // Create an Esco entity
    var escoID = int.Parse(parts[2]);
    var escoName = $"esco-{escoID.ToString()}";
    var esco = new Esco { Id = escoID, Name = escoName };
    
    var existingEsco = context.Escos.FirstOrDefault(e => e.Id == esco.Id);
    if (existingEsco == null)
    {
        context.Escos.Add(esco);
        context.SaveChanges();
        existingEsco = esco;
    }

    // Create a Customer entity
    var names = parts[1].Split(" ");
    var customer = new Customer { Id = int.Parse(parts[0]), FirstName = names[0], LastName = names[1] };
    
    var existingConsumer = context.Customers.FirstOrDefault(c => c.Id == customer.Id);
    if (existingConsumer == null)
    {
        context.Customers.Add(customer);
        
        if (existingEsco.Customers == null)
            existingEsco.Customers = new List<Customer>();
        
        existingEsco.Customers.Add(customer);
        
        context.SaveChanges();
    }

    /*// Create a ConsumerPool entity, linking the Customer and Esco
    var consumerPool = new ConsumerPool { Esco = existingEsco, Customer = existingConsumer };
    var existingConsumerPool = context.ConsumerPools
        .FirstOrDefault(cp => cp.Esco.Id == consumerPool.Esco.Id && cp.Customer.Id == consumerPool.Customer.Id);
    if (existingConsumerPool == null)
    {
        context.ConsumerPools.Add(consumerPool);
        context.SaveChanges();
    }*/
}