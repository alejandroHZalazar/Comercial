using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace Mohemby_API.Controllers;

    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService _HelloWorldService;
        private readonly ILogger<HelloWorldController> _logger;

        public HelloWorldController (IHelloWorldService HelloWorldService, ILogger<HelloWorldController> logger)
        {
            _HelloWorldService = HelloWorldService;
            _logger = logger;
        }

        public IActionResult Get()
        {
            return Ok(_HelloWorldService.GetHelloWorld());
        }


    }
