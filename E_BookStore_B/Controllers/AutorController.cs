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
    public class AutorController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public readonly IMapper _mapper;

        private readonly IMediator _mediator;
        public AutorController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetAutorByID(int Id)
        {
            var autor = new GetAutorByIDQuery(Id);
            var result = await _mediator.Send(autor);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

    }
}
