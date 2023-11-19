using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class Inactivismo_medicoController: ControllerBase
{
    public readonly IInactivismo_medicoService _inactivismoMedicoService;

    public Inactivismo_medicoController (IInactivismo_medicoService inactivismo_MedicoService)
    {
        _inactivismoMedicoService = inactivismo_MedicoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_inactivismoMedicoService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetInactivismoMedico (int id)
    {
        return Ok(_inactivismoMedicoService.GetInactivismo_Medico(id));
    }

      [HttpPost]
    public IActionResult Post([FromBody] Inactivismo_medico inactivismo_Medico)
    {
        _inactivismoMedicoService.Save(inactivismo_Medico);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put(int id, [FromBody] Inactivismo_medico inactivismo_Medico)
    {
        _inactivismoMedicoService.Update(id, inactivismo_Medico);
        return Ok();
    }

     [HttpDelete("{id}")]
    [Route("borrar/{id}")]
    public IActionResult Delete(int id)
    {
        _inactivismoMedicoService.Delete(id);
        return Ok();
    }

}