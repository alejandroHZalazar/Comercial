using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class Pol_Costo_OsController: ControllerBase
{
     public IPol_Costos_OsService _IPol_Costos_OsService;

      public Pol_Costo_OsController (IPol_Costos_OsService ipol_Costos_OsService)
    {
        _IPol_Costos_OsService = ipol_Costos_OsService;
    }

     [HttpGet]
    public IActionResult Get()
    {
        return Ok(_IPol_Costos_OsService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetPol_Costo_Os(int id)
    {
        return Ok(_IPol_Costos_OsService.GetPol_Costos_Os(id));
    }

    [HttpPost]
    public IActionResult Post ([FromBody] Pol_Costos_OS pol_Costos_OS)
    {
        _IPol_Costos_OsService.Save (pol_Costos_OS);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put (int id, [FromBody] Pol_Costos_OS pol_Costos_OS)
    {
        _IPol_Costos_OsService.Update(id, pol_Costos_OS);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("Borrar/{id}")]
    public IActionResult Delete (int id)
    {
        _IPol_Costos_OsService.Delete(id);
        return Ok();
    }
}