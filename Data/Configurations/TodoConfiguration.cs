using System.Collections.Immutable;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rest_api_dotnet_core.Models;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure(EntityTypeBuilder<Todo> builder)
    {
       List<Todo> todosInit = new List<Todo>
      {
        new Todo() { TodoId = 1, Uuid = Guid.Parse("34d722eb-5fda-4e1f-b838-150140ba4e30"), CategoryId = 1, PriorityTask = Todo.Priority.LOW, Title = "Pago de servicios publicos" },
        new Todo() { TodoId = 2, Uuid = Guid.Parse("34d722eb-5fda-4e1f-b838-150140ba4e11"), CategoryId = 2, PriorityTask = Todo.Priority.LOW, Title = "Pago de cuota" }
      };

      builder
        .ToTable("todo");
      builder
        .Property(p => p.TodoId)
        .HasColumnName("id")
        .ValueGeneratedOnAdd();
      builder
        .Property(p => p.Uuid)
        .HasColumnName("uuid");
      builder
        .HasAlternateKey(p => p.Uuid)
        .HasName("todo_uuid_unique");
      builder
        .HasOne(p => p.Category)
        .WithMany(p => p.Todos)
        .HasForeignKey(p => p.CategoryId)
        .IsRequired();
      builder
        .Property(p => p.Title)
        .IsRequired()
        .HasColumnName("title")
        .HasMaxLength(200);
      builder
        .Property(p => p.Description)
        .HasColumnName("description")
        .IsRequired(false);
      builder
        .Property(p => p.PriorityTask)
        .HasColumnName("priority_task")
        .HasDefaultValue(Todo.Priority.HIGH);
      builder
        .Property(p => p.CreationDate)
        .HasColumnName("creation_date")
        .HasDefaultValueSql("NOW()");
      builder
        .Ignore(p => p.Resume);
      builder
        .HasData(todosInit);
    }
}
