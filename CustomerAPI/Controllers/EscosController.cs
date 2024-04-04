using Entities;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace  Controller;

public class EscosController : ODataController
{
    private readonly IEscoRepository _escoRepository;

    public EscosController(IEscoRepository escoRepository)
    {
        _escoRepository = escoRepository;
    }

    [EnableQuery]
    public IQueryable<Esco> Get()
    {
        return _escoRepository.GetAll();
    }

    [EnableQuery]
    public IQueryable<Esco> Get(int key)
    {
        return _escoRepository.GetById(key);
    }

    public async Task<IActionResult> Post([FromBody] Esco esco)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _escoRepository.Create(esco);
        return Created(esco);
    }
    
    [HttpPost("odata/escos/bulk-create")]
    public async Task<IActionResult> BulkCreate([FromBody] List<Esco> escos)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await _escoRepository.BulkCreate(escos);
        return Ok();
    }

}