using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<OrderDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetOrdersHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<OrderDTO>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var books = await _uow.OrderRepository.GetOrderAsync();
            return _mapper.Map<List<OrderDTO>>(books);
        }
    }
}
