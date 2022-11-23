using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace dapr_bindings_dotnet.Controllers;

[ApiController]
[Route("[controller]")]
public class OutputsController : ControllerBase
{
    private readonly ILogger<OutputsController> _logger;

    public OutputsController(ILogger<OutputsController> logger)
    {
        _logger = logger;
    }

    [HttpPost("/invoke-http-output")]
    public async Task<ActionResult> InvokeHttpOutput([FromBody] object body)
    {
        _logger.LogInformation(body.ToString());

        //Using Dapr SDK to invoke output binding
        var bindingName = "http-output";
        var bindingOperation = "post";

        using var _daprClient = new DaprClientBuilder().Build();

        await _daprClient.InvokeBindingAsync(bindingName, bindingOperation, body);

        return Ok();
    }
}
