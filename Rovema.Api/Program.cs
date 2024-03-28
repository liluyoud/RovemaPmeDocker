using Microsoft.EntityFrameworkCore;
using Rovema.Shared.Repositories;
using Rovema.Data.Contexts;
using Rovema.Data.Repositories;
using Rovema.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RovemaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("RovemaDb"), o => o.MigrationsAssembly("Rovema.Api")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IRpaRepository, RpaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
