using E_BookStore_B.Context;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace E_BookStore_B.Data.Repo
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext appDbContext;

        public OrderRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public void AddOrder(Order order)
        {
            appDbContext.Orders.AddAsync(order);
        }

        public void DeleteOrder(int orderId)
        {
            var order = appDbContext.Orders.Find(orderId);
            appDbContext.Orders.Remove(order);
        }

        public async Task<Order> FindOrder(int bookId)
        {
            return await appDbContext.Orders.FindAsync(bookId);
        }

        public async Task<IEnumerable<Order>> GetOrderAsync()
        {
            return await appDbContext.Orders.ToListAsync();
        }

        public async Task<Order> GetOrderAsync(int id)
        {
            return await appDbContext.Orders.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}
