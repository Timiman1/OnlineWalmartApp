using OnlineWalmart.Orders.DAL.Entities;

namespace OnlineWalmart.Orders.DAL.Interfaces
{
    public interface IOrderRepository
    {
        Task<ICollection<Order>> GetAllOrdersAsync();
        Task<Order> GetOrderByIdAsync(int id);
        Task<bool> AddNewOrderAsync(Order order);
    }
}
