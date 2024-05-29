global using Microsoft.EntityFrameworkCore;
global using SuperHeroApiDotNet7.Models;
global using SuperHeroApiDotNet7.Data;
using SuperHeroApiDotNet7.Services.SuperHeroService;
using SuperHeroApiDotNet7.UnitOfWork;
using SuperHeroApiDotNet7.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//inject the request
builder.Services.AddTransient<ISuperHeroService, SuperHeroService>();

builder.Services.AddScoped<INewServices, NewServices>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWorkServices>();
builder.Services.AddScoped<ISuperHeroRepository, SuperHeroRepository>();


builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
//app.AddGlobalExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
