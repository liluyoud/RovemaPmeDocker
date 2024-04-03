using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Rovema.Data.Contexts;

namespace Rovema.Data.Extensions;

public static class MigrationExtension
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using RovemaContext context = scope.ServiceProvider.GetRequiredService<RovemaContext>();

        //context.Database.Migrate();
    }
}
