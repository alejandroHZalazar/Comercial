using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class Medico_especialidadController: ControllerBase
{
    public readonly IMedico_especialidadService _IMedico_especialidadService;

    public Medico_especialidadController (IMedico_especialidadService medico_EspecialidadService)
    {
        _IMedico_especialidadService = medico_EspecialidadService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_IMedico_especialidadService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetMedicoEspecialidad (int id)
    {
        return Ok(_IMedico_especialidadService.GetMedico_Especialidad(id));
    }

     [HttpPost]
    public IActionResult Post([FromBody] Medico_especialidad medico_Especialidad)
    {
        _IMedico_especialidadService.Save(medico_Especialidad);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put(int id, [FromBody] Medico_especialidad medico_Especialidad)
    {
        _IMedico_especialidadService.Update(id, medico_Especialidad);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("borrar/{id}")]
    public IActionResult Delete(int id)
    {
        _IMedico_especialidadService.Delete(id);
        return Ok();
    }
}