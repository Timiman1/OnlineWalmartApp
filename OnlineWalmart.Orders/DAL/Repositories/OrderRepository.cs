using Microsoft.EntityFrameworkCore;
using OnlineWalmart.Orders.DAL.Context;
using OnlineWalmart.Orders.DAL.Entities;
using OnlineWalmart.Orders.DAL.Interfaces;

namespace OnlineWalmart.Orders.DAL.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }
        public async Task<bool> AddNewOrderAsync(Order order)
        {
            try
            {
                await _context.Orders.AddAsync(order);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ICollection<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            return await _context.Orders
                .FirstOrDefaultAsync(user => user.Id == id) ?? null!;
        }
    }
}
