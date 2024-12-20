using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Repositories;
using CleanArchitecture.Persistance.Context;
using CleanArchitecture.Persistance.Repositories;
using CleanArchitecture.Persistance.Services; // CarService'in namespace'i
using CleanArchitecture.WebApi.Middleware;
using FluentValidation;
using GenericRepository;
using MediatR;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Do�ru e�le�tirme yap�l�r
builder.Services.AddScoped<ICarService, CarService>();

builder.Services.AddTransient<ExceptionMiddleware>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<AppDbContext>>();
builder.Services.AddScoped<ICarRepository, CarRepository>();

builder.Services.AddAutoMapper(typeof(CleanArchitecture.Persistance.AssemblyReference).Assembly);

string connectionString = builder.Configuration.GetConnectionString("SqlServer");

// DbContext kayd�
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Controller'lar�n eklenmesi
builder.Services.AddControllers()
    .AddApplicationPart(typeof(CleanArchitecture.Presentation.AssemblyReference).Assembly);

// MediatR yap�land�rmas�
builder.Services.AddMediatR(cfr =>
    cfr.RegisterServicesFromAssembly(typeof(CleanArchitecture.Application.AssemblyReference).Assembly));

builder.Services.AddTransient(typeof(IPipelineBehavior<,>) , typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof
    (CleanArchitecture.Application.AssemblyReference).Assembly);

// Swagger ve API Explorer
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Uygulama olu�turuluyor
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
