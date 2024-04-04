using CustomerAPI;
using Entities;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;


static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder odataBuilder = new();
    odataBuilder.EntitySet<Esco>("Escos");
    odataBuilder.EntitySet<Customer>("Customers");
    return odataBuilder.GetEdmModel();
}

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddOData(options => options
        .AddRouteComponents("odata", GetEdmModel())
        .Select()
        .Filter()
        .OrderBy()
        .SetMaxTop(20)
        .Count()
        .Expand()
    );

builder.Services
    .AddDbContext<ApplicationDbContext>(optionsBuilder => optionsBuilder.UseSqlite($"Data Source={"Data/customerData.db"}"));

builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IEscoRepository, EscoRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }