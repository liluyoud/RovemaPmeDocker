using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RovemaPme.Data.Entities;

namespace RovemaPme.Data.Contexts;

public class RovemaPmeContext(DbContextOptions<RovemaPmeContext> options) : IdentityDbContext<IdentityUser>(options)
{
    public DbSet<Rpa> Rpas { get; set; }
}