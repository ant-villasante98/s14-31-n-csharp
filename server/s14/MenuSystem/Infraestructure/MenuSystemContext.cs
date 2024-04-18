using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S14.Base.Infraestructure.Data;
using S14.MenuSystem.Domain;
using S14.MenuSystem.Infraestructure.Seeds;
using S14.UserManagment.Infraestructure;

namespace S14.MenuSystem.Infraestructure
{
    /// <summary>
    /// Context models for MenuSystem
    /// </summary>
    public partial class MenuSystemContext : DbContext
    {
        public MenuSystemContext(DbContextOptions<MenuSystemContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
            // Database.Migrate();
        }

        public DbSet<Mall> Malls { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<MenuItem> Items { get; set; }
        
        public DbSet<MenuItemCategory> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("MS");
            MallsSeed.Seed(builder);
            ShopsSeed.Seed(builder);
        }
    }
}
