using E_BookStore_B.Models;
using MediatR;

namespace E_BookStore_B.Commands
{
    public class DeliveredOrderCommand : IRequest<Order>
    {
        public int OrderId { get; set; }
        public string NewStatus { get; set; }
        public int NumOrder { get; set; }
    }
}
