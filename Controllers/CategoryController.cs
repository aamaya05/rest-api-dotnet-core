using Microsoft.AspNetCore.Mvc;
using rest_api_dotnet_core.Models;

namespace webapi.Controllers;

[Route("api/[controller]")]

public class CategoryController : ControllerBase
{
  private readonly ICategories categoryService;

  public CategoryController(ICategories service)
  {
    categoryService = service;
  }

  [HttpGet]
  public IActionResult Get()
  {
    return Ok(categoryService.Get());
  }

 [HttpPost]
  public IActionResult Post([FromBody] Category category)
  {
    categoryService.Save(category);
    return Ok();
  }

  [HttpPut("{id}")]
  public IActionResult Put(Guid id, [FromBody] Category category)
  {
    categoryService.Update(id, category);
    return Ok();
  }

  [HttpDelete("{id}")]
  public IActionResult Delete(Guid id)
  {
    categoryService.Delete(id);
    return Ok();
  }

}