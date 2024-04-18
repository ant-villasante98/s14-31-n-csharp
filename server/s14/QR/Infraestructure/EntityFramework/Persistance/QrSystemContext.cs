using Microsoft.EntityFrameworkCore;
using S14.QR.Domain;

namespace S14.QR.Infrastructure.EntityFramework.Persistance;

public class QrSystemContext : DbContext
{
    public QrSystemContext(DbContextOptions<QrSystemContext> options)
            : base(options)
    {
      //  Database.EnsureCreated();
      //  Database.Migrate();
    }

    public DbSet<Qr> Qrs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("QR");
    }
}