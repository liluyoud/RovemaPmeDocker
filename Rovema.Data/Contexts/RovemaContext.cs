using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Rovema.Shared.Entities;

namespace Rovema.Data.Contexts;

public class RovemaContext(DbContextOptions<RovemaContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Rpa> Rpas { get; set; }
    public DbSet<Powerplant> Powerplants { get; set; }
}