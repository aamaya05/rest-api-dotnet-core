using rest_api_dotnet_core.Models;

public interface ICategories
{
    IEnumerable<Category> Get();
    Task Save(Category categoria);
    Task Update(Guid id, Category categoria);
    Task Delete(Guid id);

}