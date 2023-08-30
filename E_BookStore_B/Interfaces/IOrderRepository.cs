using E_BookStore_B.Models;

namespace E_BookStore_B.Interfaces
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>> GetOrderAsync();
        Task<IEnumerable<Order>> GetOrderAsync(int id);
        void AddOrder(Order order);
        void UpdateOrder(int id);
        void DeliverOrder(int id,int numord);
        void DeleteOrder(int orderId);
        Task<Order> FindOrder(int bookId);
    }
}
