using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using S14.Base.Infraestructure.Data;
using S14.Orders.Domain;
using S14.UserManagment.Infraestructure;

namespace S14.Orders.Infrastructure
{
    public partial class OrdersSystemContext : DbContext
    {
        public OrdersSystemContext(DbContextOptions<OrdersSystemContext> options) 
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Order> Orders { get; set; }

        public DbSet<DetailOrder> Details { get; set; }

        public DbSet<HistoryState> HistoryStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("OS");
        }
    }
}