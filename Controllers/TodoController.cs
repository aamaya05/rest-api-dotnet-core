using Microsoft.AspNetCore.Mvc;
using rest_api_dotnet_core.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class TodoController : ControllerBase
{
  private readonly ITodo todoService;

  public TodoController(ITodo service)
  {
    todoService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(todoService.Get());
  }

  [HttpPost]
  public IActionResult Post([FromBody] Todo todo)
  {
    todoService.Save(todo);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Todo todo)
  {
    todoService.Update(id, todo);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    todoService.Delete(id);
    return Ok();
  }

}
