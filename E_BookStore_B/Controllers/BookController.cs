using AutoMapper;
using E_BookStore_B.Commands;
using E_BookStore_B.Data.Repo;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using E_BookStore_B.Queries;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        public readonly IMapper _mapper;

        private readonly IMediator _mediator;
        public BookController(IUnitOfWork uow, IMapper mapper, IMediator mediator)
        {
            _uow = uow;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            //throw new UnauthorizedAccessException(); greska autorizacije
            var query= new GetBooksQuery();
            var result= await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("{bookId}")]
        public async Task<IActionResult>GetBook(int bookId)
        {
            var book = new GetBookByIDQuery(bookId);
            var result= await _mediator.Send(book);
            return result !=null ?(IActionResult) Ok(result): NotFound(); 
        }

        [HttpGet("naslov")]
        public async Task<IActionResult> GetSearchBook(string naslov)
        {
            var book = new GetSearchBookByTitleQuery(naslov);
            var result = await _mediator.Send(book);
            return result != null ? (IActionResult)Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddBooks([FromBody] BookDTO bookdto) 
        {
            var book = new CreateBookCommand(bookdto);
            var result = await _mediator.Send(book);
            return Ok(result);
        }

        [HttpGet("paginacija")]
        public async Task<IActionResult> GetNewBooks(int page = 1, int pageSize = 3)
        {
            var query = new GetNewBooksQuery
            {
                Page = page,
                PageSize = pageSize
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet("toplista")]
        public async Task<IActionResult> GetTopListBooks()
        {
            //throw new UnauthorizedAccessException(); greska autorizacije
            var query = new GetBooksQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
        /* 
         * VEŽBA OSTALIH METODA *

           [HttpPut("update/{id}")]
           public async Task<IActionResult> UpdateBooks(int id,BookDTO bookdto)
           {
                   if (id != bookdto.id)
                       return BadRequest("Izmena nije dozvoljena!");
                   var bookFromDb = await _uow.BookRepository.FindBook(id);
                   if (bookFromDb == null)
                       return BadRequest("Izmena nije dozvoljena!");
                   _mapper.Map(bookdto, bookFromDb);
                   throw new Exception("Desila se neka greska");
                   await _uow.SaveAsync();
                   return StatusCode(200);          
           }
           [HttpPatch("update/{id}")]
           public async Task<IActionResult> UpdateBooksPatch(int id,JsonPatchDocument<Book> bookToPatch)
           {
               var bookFromDb = await _uow.BookRepository.FindBook(id);
               bookToPatch.ApplyTo( bookFromDb, ModelState);
               await _uow.SaveAsync();
               return StatusCode(200);
           }
           [HttpPut("updateBookKol/{id}")]
           public async Task<IActionResult> UpdateBooks(int id, BookUpdateDto bookdto)
           {
               var bookFromDb = await _uow.BookRepository.FindBook(id);
               _mapper.Map(bookdto, bookFromDb);
               await _uow.SaveAsync();
               return StatusCode(200);
           }
           [HttpDelete ("delete/{ID}")]
           public async Task<IActionResult> DeleteBooks(int id)
           {
               _uow.BookRepository.DeleteBook(id);
               await _uow.SaveAsync();
               return Ok(id);
           }
        */

    }
}
