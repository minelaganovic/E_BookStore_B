using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using E_BookStore_B.Queries;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Net.Mail;
using System.Net;
using System.Text;
using E_BookStore_B.Context;

namespace E_BookStore_B.Handlers
{
    public class UpdateOrderStatusHandler : IRequestHandler<UpdateOrderStatusCommand,Order>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly AppDbContext _authContext;
        public UpdateOrderStatusHandler(IUnitOfWork uow, IMapper mapper, AppDbContext authContext)
        {
            _uow = uow;
            _mapper = mapper;
            _authContext = authContext;

        }
        public async Task<Order> Handle(UpdateOrderStatusCommand request, CancellationToken cancellationToken)
        {

            var order = await _uow.OrderRepository.FindOrder(request.OrderId);
            // Izmena statusa narudžbine
            order.status = request.NewStatus;
            await _uow.SaveAsync();

            var user = await _authContext.Users.FindAsync(order.user_id);
            string to = user.email;
            string from = "infromacionitest@gmail.com";
            MailMessage message = new MailMessage(from, to);
            string mailBody = $"Hi {user.firstName}, <br>" + Environment.NewLine + $"Vasa porudzbina je odobrena !" + " <br> " + Environment.NewLine + $"Ukoro ce biti isporucena!";
            message.Body = mailBody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            NetworkCredential networkCredential = new NetworkCredential("infromacionitest@gmail.com", "owgnxtbvgswezkxi");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = networkCredential;
            try
            {
                client.Send(message);
            }
            catch (Exception ex) { throw ex; }
            return order;
        }
    }
}
