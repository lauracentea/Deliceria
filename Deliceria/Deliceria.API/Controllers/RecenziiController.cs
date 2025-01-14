using Deliceria.API.Repository;
using Deliceria.Data.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Deliceria.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecenziiController: ControllerBase
{
    private RecenziiRepository _recenziiRepository;
    public RecenziiController(RecenziiRepository recenziiRepository)
    {
        _recenziiRepository = recenziiRepository;
    }

    [HttpPost("/create")]
    public async Task<IActionResult> CreateRecenzie(Recenzie recenzie)
    {
        var result = this._recenziiRepository.Add(recenzie);
        return Ok(result.Entity);
    }
    
    [HttpGet("/all")]
    public async Task<IActionResult> GetAll()
    {
        var result = this._recenziiRepository.GetAll();
        return Ok(result);
    }
}