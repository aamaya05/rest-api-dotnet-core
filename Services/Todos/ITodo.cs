using rest_api_dotnet_core.Models;

public interface ITodo
{
    IEnumerable<Todo> Get();
    Task Save(Todo tarea);
    Task Update(Guid id, Todo tarea);
    Task Delete(Guid id);
}