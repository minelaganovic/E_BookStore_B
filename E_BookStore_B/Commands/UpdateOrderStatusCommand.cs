using E_BookStore_B.Models;
using MediatR;

namespace E_BookStore_B.Commands
{
    public class UpdateOrderStatusCommand:IRequest<Order>
    {
        public int OrderId { get; set; }
        public string NewStatus { get; set; }
    }
}
