using Microsoft.AspNetCore.Mvc;

namespace MCB.Demos.ShopDemo.Microservices.Customer.Services.Grpc.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1")]
public class SampleController 
    : ControllerBase
{
    [HttpGet]
    public string Test() => DateTimeOffset.UtcNow.ToString();
}
