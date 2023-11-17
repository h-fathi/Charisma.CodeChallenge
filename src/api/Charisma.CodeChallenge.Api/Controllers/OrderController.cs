namespace Charisma.CodeChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly ILogger<OrderController> _logger;
    private readonly IDispatcher _dispatcher;

    public OrderController(ILogger<OrderController> logger, IDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateOrderCommand command)
    {
       var result = await _dispatcher.SendAsync(command);
        return Ok(result);
    }

}
