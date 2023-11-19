using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class Pol_CostoController: ControllerBase
{
    public Ipol_CostoService _IPolCostoService;

     public Pol_CostoController (Ipol_CostoService ipol_CostoService)
    {
        _IPolCostoService = ipol_CostoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_IPolCostoService.Get());
    }

      [HttpGet("{id}")]
    public IActionResult GetPol_Costo(int id)
    {
        return Ok(_IPolCostoService.GetPol_Costo(id));
    }

      [HttpPost]

    public IActionResult Post ([FromBody] pol_Costo pol_costo)
    {
        _IPolCostoService.Save (pol_costo);
        return Ok();
    }

      [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put (int id, [FromBody] pol_Costo pol_costo)
    {
        _IPolCostoService.Update(id, pol_costo);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("Borrar/{id}")]
    public IActionResult Delete (int id)
    {
        _IPolCostoService.Delete(id);
        return Ok();
    }
}