using Entities;

namespace CustomerAPI.Repositories;

public interface IEscoRepository
{
    IQueryable<Esco> GetAll();
    IQueryable<Esco> GetById(int id);
    Task Create(Esco esco);
    Task BulkCreate(List<Esco> escos);
}

