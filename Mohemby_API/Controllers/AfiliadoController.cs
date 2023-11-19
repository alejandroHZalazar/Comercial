
using Mohemby_API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Mohemby_API.Modelos;

namespace Mohemby_API.Controllers;

[Route ("api/[controller]")]
[Authorize]

public class AfiliadoController: ControllerBase
{
    private readonly IAfiliadoService _afiliadoService;

    public AfiliadoController (IAfiliadoService afiliadoService)
    {
        _afiliadoService = afiliadoService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(_afiliadoService.Get());
    }

    [HttpGet("{id}")]
    public IActionResult GetAfiliado (int id)
    {
        return Ok(_afiliadoService.GetAfiliado(id));
    }

    [HttpPost]
    public IActionResult Post([FromBody] Afiliado afiliado)
    {
        _afiliadoService.Save(afiliado);
        return Ok();
    }

    [HttpPut("{id}")]
    [Route("Actualizar/{id}")]
    public IActionResult Put (int id, [FromBody] Afiliado afiliado)
    {
        _afiliadoService.Update(id, afiliado);
        return Ok();
    }

    [HttpDelete("{id}")]
    [Route("Borrar/{id}")]
    public IActionResult Delete (int id)
    {
        _afiliadoService.Delete(id);
        return Ok();
    }

}