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
        public Task<bool> AddNewOrderAsync(Order order)
        {
            throw new NotImplementedException();
            //try
            //{
            //    await _context.Orders.AddAsync();
            //    return true;
            //}
            //catch
            //{
            //    return false;
            //}
        }

        public Task<ICollection<Order>> GetAllOrdersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Order> GetOrderByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
