using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.Context;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using System.Net.Mail;
using System.Net;
using System.Text;
using MediatR;
using Microsoft.Identity.Client.Extensibility;

namespace E_BookStore_B.Handlers
{
    public class DeliverOrderHandler: IRequestHandler<DeliveredOrderCommand, Order>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public DeliverOrderHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<Order> Handle(DeliveredOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _uow.OrderRepository.FindOrder(request.OrderId);
            order.status = request.NewStatus;
            //order.kolicina = request.NumOrder;
            var book = await _uow.BookRepository.FindBook(order.book_id);
            if (book != null)
            {
                book.kolicina = book.kolicina- request.NumOrder;
            }
            await _uow.SaveAsync();
            return order;
        }
    }
}
