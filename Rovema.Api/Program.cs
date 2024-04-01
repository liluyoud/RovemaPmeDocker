using Microsoft.EntityFrameworkCore;
using Rovema.Data.Contexts;
using Rovema.Data.Extensions;
using Rovema.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RovemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RovemaDb"), o => o.MigrationsAssembly("Rovema.Api")));

builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = builder.Configuration.GetConnectionString("RovemaCache"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.MapRpaEndpoints();

app.Run();
