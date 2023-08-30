using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using E_BookStore_B.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;
using System.Text;

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

        [HttpPut("{id}/odobriti")]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            var command = new UpdateOrderStatusCommand { OrderId = id, NewStatus = "odobreno" };

            var result = await _mediator.Send(command);

            return Ok(result);
            
        }

        /*[HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, User ur)
        {
            var user = await _authContext.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.status = ur.status;

            string to = user.email;
            string from = "infromacionitest@gmail.com";
            MailMessage message = new MailMessage(from, to);
            string mailBody = $"Hi {user.firstName}, <br>" + Environment.NewLine + $"Vas zahtev za registraciju je prihvacen !" + " <br> " + Environment.NewLine + $"Loguj te ste http://localhost:4200/ ";
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
            await _authContext.SaveChangesAsync();

            return Ok(user);
        }*/

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
