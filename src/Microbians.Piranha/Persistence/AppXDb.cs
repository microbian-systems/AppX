﻿namespace Microbians.Piranha.Persistence;

public abstract class AppXDb<T>(DbContextOptions<T> options) 
    : Db<T>(options)
    where T : Db<T>
{
    /// <summary>
    ///     Creates and configures the data model.
    /// </summary>
    /// <param name="mb">The current model builder</param>
    protected override void OnModelCreating(ModelBuilder mb)
    {
        base.OnModelCreating(mb);

        mb.Entity<User>().ToTable("AppX.Users");
        mb.Entity<Role>().ToTable("Piranha.Roles");
        mb.Entity<IdentityUserClaim<Guid>>().ToTable("Piranha.UserClaims");
        mb.Entity<IdentityUserRole<Guid>>().ToTable("Piranha.UserRoles");
        mb.Entity<IdentityUserLogin<Guid>>().ToTable("Piranha.UserLogins");
        mb.Entity<IdentityRoleClaim<Guid>>().ToTable("Piranha.RoleClaims");
        mb.Entity<IdentityUserToken<Guid>>().ToTable("Piranha.UserTokens");
    }
}