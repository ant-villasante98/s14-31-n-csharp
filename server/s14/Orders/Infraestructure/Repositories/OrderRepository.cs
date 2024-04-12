using Microsoft.EntityFrameworkCore;
using S14.Orders.Domain;
using S14.Orders.Infrastructure;
using S14.Orders.Infrastructure.Repositories;

namespace S14.Orders.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrdersSystemContext _context;
        
        public OrderRepository(OrdersSystemContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.Details)
                .FirstOrDefaultAsync(o => o.Id == orderId);
        }

        public async Task<IEnumerable<Order>> GetOrdersAsync(int userId)
        {
            return await _context.Orders
                .Include(o => o.Details)
                .Where(o => o.UserId == userId)
                .ToListAsync();
        }

        public async Task AddAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
        }

        public async Task UpdateAsync(Order order)
        {
            _context.Orders.Update(order);
        }

        public async Task DeleteAsync(Order order)
        {
            _context.Orders.Remove(order);
        }
    }
}