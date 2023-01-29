using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;
using rest_api_dotnet_core;
using rest_api_dotnet_core.Middleware;
using weapi.Services.Categories;
using webapi.Services.Todos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
  option.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo API", Version = "v1" });
  option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
  {
    In = ParameterLocation.Header,
    Description = "Please enter a valid token",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    BearerFormat = "JWT",
    Scheme = "Bearer"
  });
  option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddMvc().AddJsonOptions(options =>
{
  var enumConverter = new JsonStringEnumConverter();
  options.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.AddNpgsql<AppDbContext>(builder.Configuration.GetConnectionString("development"));
//builder.Services.AddScoped<IHelloWorld, HelloWorld>();
builder.Services.AddScoped<ICategories, CategoriesService>();
builder.Services.AddScoped<ITodo, TodoService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//app.UseTimeMiddleware();

app.MapControllers();

app.Run();
