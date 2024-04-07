using Entities;
using CustomerAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace  Controller;

public class EscosController(IEscoRepository escoRepository) : ODataController
{
    [EnableQuery]
    public IQueryable<Esco> Get()
    {
        return escoRepository.GetAll();
    }

    [EnableQuery]
    public IQueryable<Esco> Get(int key)
    {
        return escoRepository.GetById(key);
    }

    public async Task<IActionResult> Post([FromBody] Esco esco)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await escoRepository.Create(esco);
        return Created(esco);
    }
    
    [HttpPost("odata/escos/bulk-create")]
    public async Task<IActionResult> BulkCreate([FromBody] List<Esco> escos)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        await escoRepository.BulkCreate(escos);
        return Ok();
    }

}