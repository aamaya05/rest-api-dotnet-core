using rest_api_dotnet_core;
using rest_api_dotnet_core.Models;

namespace webapi.Services.Todos;

public class TodoService : ITodo
{
  readonly AppDbContext context;
  public TodoService(AppDbContext dbContext)
  {
    context = dbContext;
  }
  public IEnumerable<Todo> Get()
  {
    return context.Todos;
  }

  public async Task Save(Todo todo)
  {
    context.Add(todo);
    await context.SaveChangesAsync();
  }

  public async Task Update(Guid id, Todo todo)
  {
    var actualTodo = context.Todos.Find(id);

    if (actualTodo != null)
    {
      actualTodo.CategoryId = todo.CategoryId;
      actualTodo.Title = todo.Title;
      actualTodo.PriorityTask = todo.PriorityTask;
      actualTodo.Description = todo.Description;

      await context.SaveChangesAsync();
    }
  }

  public async Task Delete(Guid id)
  {
    var actualTodo = context.Todos.Find(id);

    if (actualTodo != null)
    {
      context.Remove(actualTodo);
      await context.SaveChangesAsync();
    }
  }
}