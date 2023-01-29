using Microsoft.EntityFrameworkCore;
using rest_api_dotnet_core.Models;

namespace rest_api_dotnet_core;

public class AppDbContext : DbContext
{
  public DbSet<Category> Categories { get; set; }

  public DbSet<Todo> Todos { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
  {
    Npgsql.NpgsqlConnection.GlobalTypeMapper.MapEnum<Todo.Priority>();
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new CategoryConfiguration());
    modelBuilder.ApplyConfiguration(new TodoConfiguration());
    modelBuilder.HasPostgresEnum<Todo.Priority>();
  }
}