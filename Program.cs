using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Proyecto_Funda_Arqui.Data;
using Proyecto_Funda_Arqui.Services;
using System;
using Proyecto_Funda_Arqui.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configuración de la cadena de conexión
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configurar servicios
builder.Services.AddControllers();

// Configurar Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Proyecto_Funda_Arqui API", Version = "v1" });
});

// Configuración del contexto de base de datos
builder.Services.AddDbContext<CursoContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

// Configurar servicios de aplicación
builder.Services.AddScoped<ICursoService, CursoService>();
builder.Services.AddScoped<IProfesorService, ProfesorService>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();

builder.Services.AddScoped<ICursoRepository, CursoRepository>();
builder.Services.AddScoped<IProfesorRepository, ProfesorRepository>();
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

// Configurar Swagger UI
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Proyecto_Funda_Arqui API V1");
    c.RoutePrefix = string.Empty; // Servir Swagger en la raíz del sitio
});

// Middleware y enrutamiento
app.UseHttpsRedirection(); // Redireccionamiento HTTPS
app.UseAuthorization(); // Autorización

app.MapControllers(); // Mapear los controladores

app.Run(); // Ejecutar la aplicación