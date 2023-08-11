using AutoMapper;
using E_BookStore_B.Data.Repo;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
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

        public BookController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            throw new UnauthorizedAccessException();
            var books= await _uow.BookRepository.GetBooksAsync();
            var book = _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooks(BookDTO bookdto) 
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var book = _mapper.Map<Book>(bookdto);
            _uow.BookRepository.AddBook(book);
            await _uow.SaveAsync();
            return StatusCode(201);
        }
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

    }
}
