using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Rovema.Data.Contexts;
using Rovema.Data.Extensions;
using Rovema.Shared.Contracts;
using Rovema.Shared.Entities;

namespace Rovema.Api.Endpoints;

public static class RpaEndpoints
{
    public static void MapRpaEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("rpas", async (
            CreateRpaResquest request,
            RovemaContext context,
            CancellationToken ct) =>
        {
            var rpa = new Rpa
            {
                Name = request.Name,
                Type = request.Type,
                TimeZone = request.TimeZone,
                TimeToFail = request.TimeToFail,
                Active = true
            };

            context.Add(rpa);

            await context.SaveChangesAsync(ct);

            return Results.Ok(rpa);
        });

        app.MapGet("rpas", async (
            RovemaContext context,
            CancellationToken ct) =>
        {
            var rpas = await context.Rpas
                .AsNoTracking()
                .ToListAsync(ct);

            return Results.Ok(rpas);
        });

        app.MapGet("rpas/{id}", async (
            Guid id,
            RovemaContext context,
            IDistributedCache cache,
            CancellationToken ct) =>
        {
            var product = await cache.GetAsync($"rpa-{id}",
                async token =>
                {
                    var rpas = await context.Rpas
                        .AsNoTracking()
                        .FirstOrDefaultAsync(p => p.Id == id, token);

                    return rpas;
                },
                new() { AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(20) },
                ct);

            return product is null ? Results.NotFound() : Results.Ok(product);
        });

        app.MapPut("rpas/{id}", async (
            Guid id,
            UpdateRpaRequest request,
            RovemaContext context,
            IDistributedCache cache,
            CancellationToken ct) =>
        {
            var rpa = await context.Rpas.FindAsync(id, ct);

            if (rpa is null)
            {
                return Results.NotFound();
            }

            if (rpa.Id == request.Id)
            {
                rpa.Name = request.Name;
                rpa.Type = request.Type;
                rpa.TimeZone = request.TimeZone;
                rpa.TimeToFail = request.TimeToFail;
                rpa.Active = request.Active;

                await context.SaveChangesAsync(ct);

                await cache.RemoveAsync($"rpa-{id}", ct);
            }

            return Results.NoContent();
        });

        app.MapDelete("rpas/{id}", async (
            int id,
            RovemaContext context,
            IDistributedCache cache,
            CancellationToken ct) =>
        {
            var rpa = await context.Rpas.FindAsync(id, ct);

            if (rpa is null)
            {
                return Results.NotFound();
            }

            context.Remove(rpa);

            await context.SaveChangesAsync(ct);

            await cache.RemoveAsync($"rpa-{id}", ct);

            return Results.NoContent();
        });
    }
}
