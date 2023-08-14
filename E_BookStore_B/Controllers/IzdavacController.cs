using AutoMapper;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class IzdavacController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public readonly IMapper _mapper;

        private readonly IMediator _mediator;
        public IzdavacController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetIzdavacByID(int Id)
        {
            var izdavac = new GetIzdavacByIDQuery(Id);
            var result = await _mediator.Send(izdavac);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }
    }
}
