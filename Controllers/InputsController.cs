using Microsoft.AspNetCore.Mvc;

namespace dapr_bindings_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class InputsController : ControllerBase
{
    private readonly ILogger<InputsController> _logger;

    public InputsController(ILogger<InputsController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public ActionResult Hello()
    {
        return Ok("Hello bindins demo");
    }

    [HttpPost("/scheduled")]
    public ActionResult scheduled()
    {
        _logger.LogInformation($"Scheduled fired at {DateTime.Now}");

        return Ok(); //ACK-ing an event
    }

    [HttpPost("/azqueue")]
    public ActionResult azqueue([FromBody] object message)
    {
        _logger.LogInformation($"New queue message:");
        _logger.LogInformation(message.ToString());

        return Ok(); //ACK-ing an event
    }

    [HttpPost("/tweets")]
    public ActionResult tweets([FromBody] object body)
    {
        _logger.LogInformation(body.ToString());

        return Ok(); //ACK-ing an event
    }
}
