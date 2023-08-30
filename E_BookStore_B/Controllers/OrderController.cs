using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public readonly IMapper _mapper;

        private readonly IMediator _mediator;
        public OrderController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderdto)
        {
            var order = new CreateOrderCommand(orderdto);
            var result = await _mediator.Send(order);
            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetBookGetOrderAsync(int userId)
        {
            var order = new GetOrderByUIDQuery(userId);
            var result = await _mediator.Send(order);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var query = new GetOrdersQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
