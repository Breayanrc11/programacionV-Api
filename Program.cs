using Microsoft.EntityFrameworkCore;
using ProgramacionV.Api.Data;
using ProgramacionV.Api.Repositories;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddDbContext<AppDbContext>(options => {
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddScoped<ProgramaRepository>();
builder.Services.AddScoped<EstudianteRepository>();
var app = builder.Build();
app.MapOpenApi();
app.MapScalarApiReference(options => {
    options.WithTitle("Programación V - API Gestión Académica");
});
app.MapGet("/", () => Results.Redirect("/scalar/v1"));
app.MapControllers();
app.Run();