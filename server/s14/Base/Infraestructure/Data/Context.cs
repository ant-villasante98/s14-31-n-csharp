using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S14.UserManagment.Infraestructure;

namespace S14.Base.Infraestructure.Data
{
    public class Context
        : IdentityDbContext<AppUser, IdentityRole<int>, int>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Context"/> class.
        /// </summary>
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            UserSeed.Seed(builder);
            base.OnModelCreating(builder);
        }
    }
}
