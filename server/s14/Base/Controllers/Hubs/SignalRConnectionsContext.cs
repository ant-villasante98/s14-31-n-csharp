using Microsoft.EntityFrameworkCore;

namespace S14.Base.Controllers.Hubs
{
    public class SignalRConnectionsContext : DbContext
    {
        public DbSet<HubConnection> Connections { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "ConnectionsContext");
        }
    }

    public class HubConnection
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string ConnectionId { get; set; }

        public DateTime StartedAt { get; set; }

        public bool IsActive { get; set; }

        public string LastIp { get; set; }
    }
}
