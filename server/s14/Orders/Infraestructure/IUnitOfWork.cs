using S14.Orders.Infrastructure.Repositories;

namespace S14.Orders.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository OrderRepository { get; }

        Task<int> SaveChangesAsync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();

        Task RollbackAsync();
    }
}