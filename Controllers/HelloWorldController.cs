using Microsoft.AspNetCore.Mvc;
using rest_api_dotnet_core;

namespace webapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HelloWorldController : ControllerBase
{
  private readonly IHelloWorld helloWorldService;
  readonly AppDbContext dbContext;

  public HelloWorldController(IHelloWorld helloWorld, AppDbContext db)
  {
    helloWorldService = helloWorld;
    dbContext = db;
  }

  [HttpGet]
  
  public IActionResult Get()
  {
    return Ok(helloWorldService.GetHelloWorld());
  }

  [HttpGet]
  [Route("createDb")]
  public IActionResult CreateDatabase()
  {
    return Ok();
  }

}