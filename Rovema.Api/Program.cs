using Microsoft.EntityFrameworkCore;
using Rovema.Data.Contexts;
using Rovema.Data.Extensions;
using Rovema.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var redisUrl = Environment.GetEnvironmentVariable("REDIS_URL");
var postgresHost = Environment.GetEnvironmentVariable("POSTGRES_HOST");
var postgresUsername = Environment.GetEnvironmentVariable("POSTGRES_USERNAME");
var postgresPassword = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD");
var postgresDatabase = Environment.GetEnvironmentVariable("POSTGRES_DATABASE");
var postgresConnection = $"Host={postgresHost};Port=5432;Database={postgresDatabase};Username={postgresUsername};Password={postgresPassword};Include Error Detail=true";

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<RovemaContext>(options =>
    options.UseNpgsql(postgresConnection, o => o.MigrationsAssembly("Rovema.Api")));

builder.Services.AddStackExchangeRedisCache(options =>
    options.Configuration = redisUrl);

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
