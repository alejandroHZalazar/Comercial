using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class EspecialidadController: ControllerBase
{
    private readonly IEspecialidadService _especialidadService;

    public EspecialidadController (IEspecialidadService especialidadService)
    {
        _especialidadService = especialidadService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_especialidadService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetEspecialidad (int id)
    {
        return Ok(_especialidadService.GetEspecialidad(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Especialidad especialidad)
    {
        _especialidadService.Save(especialidad);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("Actualizar/{id}")]
    public IActionResult Put (int id, [FromBody] Especialidad especialidad)
    {
        _especialidadService.Update(id, especialidad);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("Borrar/{id}")]
    public IActionResult Delete (int id)
    {
        _especialidadService.Delete(id);
        return Ok();
    }

    
}