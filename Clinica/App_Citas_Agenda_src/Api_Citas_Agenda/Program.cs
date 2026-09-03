using Persistence;
using Core;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

/* Inyeccion del servicio Persistencia */
builder.Services.AddPersistence();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

/* */
builder.Services.AddCore();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();