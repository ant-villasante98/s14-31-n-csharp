using Microsoft.EntityFrameworkCore;
using S14.Payments.Domain;

namespace S14.Payments.Infraestructure;

public class PaymentsSystemContext : DbContext
{
    public PaymentsSystemContext(DbContextOptions<PaymentsSystemContext> dbContext) 
        : base(dbContext)
    {
        Database.EnsureCreated();
        Database.Migrate();
    }

    public DbSet<Payment> Payments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("PS");
    }
}
