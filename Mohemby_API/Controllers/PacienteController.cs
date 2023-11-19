using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class PacienteController: ControllerBase
{
    public IPacienteService _IPacienteService;

    public PacienteController (IPacienteService iPacienteService)
    {
        _IPacienteService = iPacienteService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_IPacienteService.Get());
    }

     [HttpGet("{id}")]
    public IActionResult GetPaciente(int id)
    {
        return Ok(_IPacienteService.GetPaciente(id));
    }

    [HttpPost]

    public IActionResult Post ([FromBody] Paciente paciente)
    {
        _IPacienteService.Save (paciente);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put (int id, [FromBody] Paciente paciente)
    {
        _IPacienteService.Update(id, paciente);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("Borrar/{id}")]
    public IActionResult Delete (int id)
    {
        _IPacienteService.Delete(id);
        return Ok();
    }
}