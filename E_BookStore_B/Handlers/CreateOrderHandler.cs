using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class CreateOrderHandler:IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public CreateOrderHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _mapper.Map<Order>(request.orderDTO);
            _uow.OrderRepository.AddOrder(order);
            await _uow.SaveAsync();
            return order;
        }
    }
}
