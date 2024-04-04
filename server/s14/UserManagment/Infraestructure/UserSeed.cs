using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace S14.UserManagment.Infraestructure
{
    public static class UserSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder = builder ?? throw new ArgumentNullException(nameof(builder));
            var hasher = new PasswordHasher<AppUser>();

#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
            var users = new[]
            {
                new AppUser
                {
                    Id = 1,
                    UserName = "admin@gmail.com",
                    NormalizedUserName = "ADMIN@GMAIL.COM",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "Admin123!"), // Hash de la contraseña
                    SecurityStamp = string.Empty,
                },
                new AppUser
                {
                    Id = 2,
                    UserName = "user@gmail.com",
                    NormalizedUserName = "USER1@GMAIL.COM",
                    Email = "user@gmail.com",
                    NormalizedEmail = "USER1@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "User123!"), // Hash de la contraseña
                    SecurityStamp = string.Empty,
                },
                new AppUser
                {
                    Id = 3,
                    UserName = "agent@gmail.com",
                    NormalizedUserName = "AGENT@GMAIL.COM",
                    Email = "agent@gmail.com",
                    NormalizedEmail = "AGENT@GMAIL.COM",
                    EmailConfirmed = false,
                    PasswordHash = hasher.HashPassword(null, "Agent123!"), // Hash de la contraseña
                    SecurityStamp = string.Empty,
                },
            };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

            builder.Entity<AppUser>().HasData(users);

            var roles = new[]
            {
                new IdentityRole<int>()
                {
                    Id = 1,
                    Name = "admin",
                    NormalizedName = "ADMIN",
                },
                new IdentityRole<int>()
                {
                    Id = 2,
                    Name = "user",
                    NormalizedName = "USER",
                },
                new IdentityRole<int>()
                {
                    Id = 3,
                    Name = "Agent",
                    NormalizedName = "AGENT",
                },
            };

            builder.Entity<IdentityRole<int>>().HasData(roles);

            var userRoles = new[]
            {
                new IdentityUserRole<int>()
                {
                    UserId = 1,
                    RoleId = 1,
                },
                new IdentityUserRole<int>()
                {
                    UserId = 2,
                    RoleId = 2,
                },
                new IdentityUserRole<int>()
                {
                    UserId = 3,
                    RoleId = 3,
                },
            };
            builder.Entity<IdentityUserRole<int>>().HasData(userRoles);
        }
    }
}
