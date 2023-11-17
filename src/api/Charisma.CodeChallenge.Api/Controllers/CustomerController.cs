namespace Charisma.CodeChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly IDispatcher _dispatcher;

    public CustomerController(ILogger<CustomerController> logger, IDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateCustomerCommand command)
    {
       var result = await _dispatcher.SendAsync(command);
        return Ok(result);
    }

}
