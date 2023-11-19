using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class MedicoController : ControllerBase
{

    public IMedicoService _iMedicoService;

    public MedicoController (IMedicoService iMedicoService)
    {
        _iMedicoService = iMedicoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_iMedicoService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetMedico(int id)
    {
        return Ok(_iMedicoService.GetMedico(id));
    }

    [HttpPost]

    public IActionResult Post ([FromBody] Medico medico)
    {
        _iMedicoService.save (medico);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put (int id, [FromBody] Medico medico)
    {
        _iMedicoService.update(id, medico);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("Borrar/{id}")]
    public IActionResult Delete (int id)
    {
        _iMedicoService.Delete(id);
        return Ok();
    }


}