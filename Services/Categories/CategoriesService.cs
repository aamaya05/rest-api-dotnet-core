using rest_api_dotnet_core;
using rest_api_dotnet_core.Models;

namespace weapi.Services.Categories;

public class CategoriesService : ICategories
{
  readonly AppDbContext context;

  public CategoriesService(AppDbContext dbContext)
  {
    context = dbContext;
  }

  public IEnumerable<Category> Get()
  {
    return context.Categories;
  }

  public async Task Save(Category categoria)
  {
    context.Add(categoria);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Category categoria)
  {
    var actualCategory = context.Categories.Find(id);
    if (actualCategory != null)
    {
      actualCategory.Name = categoria.Name;
      actualCategory.Description = categoria.Description;
      actualCategory.Point = categoria.Point;

      await context.SaveChangesAsync();
    }

  }

  public async Task Delete(Guid id)
  {
    var actualCategory = context.Categories.Find(id);
    if (actualCategory != null)
    {
      context.Remove(actualCategory);
      await context.SaveChangesAsync();
    }
  }

}