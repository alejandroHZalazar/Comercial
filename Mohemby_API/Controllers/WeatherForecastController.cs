using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading;

namespace Mohemby_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    //creamos una lista para que perduren los datos durante la ejecucion
        private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
         //si la lista esta vacía o no tiene ningún registro
            if (ListWeatherForecast == null || !ListWeatherForecast.Any())
            {
                 var rng = new Random();
                ListWeatherForecast =  Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToList();

            }
    }

    [HttpGet(Name = "GetCadena")]
    [Route("[action]")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("retornando la lista");
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post (WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete (int index)
    {
        try
        {
            ListWeatherForecast.RemoveAt(index);
            
        }
        catch (ArgumentOutOfRangeException)
        {
            return BadRequest (new {msg = $"No existe el índice:{index}"});
        }

        return Ok(new {msg="Eliminado!!"});
    }
}
