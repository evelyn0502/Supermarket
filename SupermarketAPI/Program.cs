using CapaDatos;
using CapaNegocio.Clases;
using CapaNegocio.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//configuracion a base de datos
var conn = builder.Configuration.GetConnectionString("AppConnection");//creacion variable de conexion
builder.Services.AddDbContext<ApiContext>(x => x.UseSqlServer(conn));//construye contexto 

//configuracion de las interfaces para que el controlador las pueda usar
builder.Services.AddScoped<ISupermarket,LogicSupermarket>();

builder.Services.AddScoped<IProduct, LogicProduct>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
