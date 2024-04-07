using Entities;
using Microsoft.EntityFrameworkCore;

namespace CustomerAPI.Repositories;

public class EscoRepository(ApplicationDbContext context) : IEscoRepository
{
    public  IQueryable<Esco> GetAll()
    {
        return context.Escos.AsQueryable();
    }

    public IQueryable<Esco> GetById(int id)
    {
        return context.Escos.Where(x=> x.Id == id);
    }

    public async Task Create(Esco esco)
    {
        context.Escos.Add(esco);
        await context.SaveChangesAsync();
    }

    public async Task BulkCreate(List<Esco> escos)
    {
        await context.Escos.AddRangeAsync(escos);
        await context.SaveChangesAsync();
    }
}
