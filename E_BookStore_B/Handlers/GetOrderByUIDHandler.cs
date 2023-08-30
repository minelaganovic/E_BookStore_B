using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;
using System.Collections.Generic;

namespace E_BookStore_B.Handlers
{    public class GetOrderByUIDHandler : IRequestHandler<GetOrderByUIDQuery, List<OrderDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetOrderByUIDHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task <List<OrderDTO>> Handle(GetOrderByUIDQuery request, CancellationToken cancellationToken)
        {
            var orderss = await _uow.OrderRepository.GetOrderAsync(request.UserID);
            if (orderss == null)
            {
                return null;
            }
            return _mapper.Map<List<OrderDTO>>(orderss);
        }
    }
}
