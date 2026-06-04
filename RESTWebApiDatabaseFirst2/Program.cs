using Microsoft.EntityFrameworkCore;
using RESTWebApiDatabaseFirst2.Data;
using RESTWebApiDatabaseFirst2.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IDBService, DBService>();

builder.Services.AddDbContext<DatabaseFirstContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        // Wskazujemy Swaggerowi, gdzie .NET 9 generuje plik specyfikacji OpenAPI
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
