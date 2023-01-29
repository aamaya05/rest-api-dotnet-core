using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using rest_api_dotnet_core.Models;

#nullable disable

namespace rest_api_dotnet_core.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:priority", "low,medium,high");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    Point = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "todo",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    uuid = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    priority_task = table.Column<Todo.Priority>(type: "priority", nullable: false, defaultValue: Todo.Priority.HIGH),
                    creation_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false, defaultValueSql: "NOW()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_todo", x => x.id);
                    table.UniqueConstraint("todo_uuid_unique", x => x.uuid);
                    table.ForeignKey(
                        name: "FK_todo_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "category",
                columns: new[] { "id", "description", "name", "Point", "Uuid" },
                values: new object[,]
                {
                    { 1, null, "Actividades Pendientes", 20, new Guid("9cfab1c9-c234-42e4-a64f-78be3eb8e12d") },
                    { 2, null, "Actividades Personales", 20, new Guid("9cfab1c9-c234-42e4-a64f-78be3eb8e56d") }
                });

            migrationBuilder.InsertData(
                table: "todo",
                columns: new[] { "id", "CategoryId", "description", "title", "uuid" },
                values: new object[,]
                {
                    { 1, 1, null, "Pago de servicios publicos", new Guid("34d722eb-5fda-4e1f-b838-150140ba4e30") },
                    { 2, 2, null, "Pago de cuota", new Guid("34d722eb-5fda-4e1f-b838-150140ba4e11") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_todo_CategoryId",
                table: "todo",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "todo");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
