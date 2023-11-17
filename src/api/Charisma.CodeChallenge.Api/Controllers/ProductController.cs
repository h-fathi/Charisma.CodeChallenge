namespace Charisma.CodeChallenge.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly IDispatcher _dispatcher;

    public ProductController(ILogger<ProductController> logger, IDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateProductCommand command)
    {
       var result = await _dispatcher.SendAsync(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _dispatcher.QueryAsync(new GetProductsQuery());
        return Ok(result);
    }
}
