using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class HorarioController: ControllerBase
{
    private readonly IHorarioService _horarioService;

    public HorarioController(IHorarioService horarioService)
    {
        _horarioService = horarioService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_horarioService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetHorario (int id)
    {
        return Ok(_horarioService.GetHorario(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Horario horario)
    {
        _horarioService.Save(horario);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("actualizar/{id}")]
    public IActionResult Put(int id, [FromBody] Horario horario)
    {
        _horarioService.Update(id, horario);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("borrar/{id}")]
    public IActionResult Delete(int id)
    {
        _horarioService.Delete(id);
        return Ok();
    }
}