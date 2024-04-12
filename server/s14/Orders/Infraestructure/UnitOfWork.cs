using S14.Orders.Infrastructure.Repositories;

namespace S14.Orders.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OrdersSystemContext _context;
        
        public UnitOfWork(OrdersSystemContext context)
        {
            _context = context;
        }

        public IOrderRepository OrderRepository => new OrderRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}