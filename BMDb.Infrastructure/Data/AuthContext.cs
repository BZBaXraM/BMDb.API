using BMDb.API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BMDb.API.Data;

/// <inheritdoc />
public class AuthContext : IdentityDbContext<AppUser>
{
    /// <inheritdoc />
    public AuthContext(DbContextOptions<AuthContext> options) : base(options)
    {
    }
    /// <summary>
    /// Users DbSet
    /// </summary>
    public override DbSet<AppUser> Users => Set<AppUser>();
}