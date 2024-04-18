using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using S14.Orders.Infrastructure.Repositories;

namespace S14.Orders.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction _dbContextTransaction { get; set; }
        private readonly OrdersSystemContext _context;

        public IOrderRepository OrderRepository { get; }

        public UnitOfWork(OrdersSystemContext context)
        {
            _context = context;
            OrderRepository = new OrderRepository(_context);
        }


        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task BeginTransactionAsync()
        {
            _dbContextTransaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _dbContextTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbContextTransaction.RollbackAsync();
        }
    }
}