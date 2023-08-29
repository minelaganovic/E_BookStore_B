using E_BookStore_B.DTOs;
using E_BookStore_B.Models;
using MediatR;

namespace E_BookStore_B.Commands
{
    public class CreateOrderCommand:IRequest<Order>
    {


        public OrderDTO orderDTO { get; }
        public CreateOrderCommand(OrderDTO orderDTO)
        {
            this.orderDTO = orderDTO;
        }
    }
}
