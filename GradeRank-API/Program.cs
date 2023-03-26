using GradeRank_Application.Interfaces;
using GradeRank_Application.UseCases;
using GradeRank_Domain.Repositories;
using GradeRank_Infrastructure.Context;
using GradeRank_Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Logging.AddConsole();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHealthStatusUseCase, HealthStatusUseCase>();
builder.Services.AddScoped<IHealthStatusRepository, HealthStatusRepository>();

builder.Services.AddDbContext<GradeRankContext>(
                        (prv, options) =>
                        {
                          options.UseSqlServer(builder.Configuration.GetConnectionString("GradeRankDataBase") ?? string.Empty);

                          options.EnableSensitiveDataLogging();
                        });

var app = builder.Build();

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
  app.UseDeveloperExceptionPage();
  app.UseSwagger();
  app.UseSwaggerUI();

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
