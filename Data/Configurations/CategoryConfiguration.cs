using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using rest_api_dotnet_core.Models;

public class CategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
       List<Category> categoriesInit = new List<Category>
      {
        new Category() { CategoryId = 1, Uuid = Guid.Parse("9cfab1c9-c234-42e4-a64f-78be3eb8e12d"), Name = "Actividades Pendientes", Point = 20 },
        new Category() { CategoryId = 2 ,Uuid = Guid.Parse("9cfab1c9-c234-42e4-a64f-78be3eb8e56d"), Name = "Actividades Personales", Point = 20 }
      };

        builder
          .ToTable("category");
        builder
          .Property(p => p.CategoryId)
          .HasColumnName("id")
          .ValueGeneratedOnAdd();
        builder
          .Property(p => p.Name)
          .IsRequired()
          .HasColumnName("name")
          .HasMaxLength(150);
        builder
          .Property(p => p.Description)
          .IsRequired(false)
          .HasColumnName("description");
        builder
          .Property(c => c.Point);
        builder
          .HasData(categoriesInit);
    }
}
