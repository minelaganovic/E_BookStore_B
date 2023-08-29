using E_BookStore_B.Models;

namespace E_BookStore_B.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderAsync();
        Task<Order> GetOrderAsync(int id);
        void AddOrder(Order order);
        void DeleteOrder(int orderId);
        Task<Order> FindOrder(int bookId);
    }
}
