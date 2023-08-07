using AutoMapper;
using E_BookStore_B.Data.Repo;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            var books= await _uow.BookRepository.GetBooksAsync();
            var book = _mapper.Map<IEnumerable<BookDTO>>(books);
            return Ok(book);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooks(BookDTO bookdto) 
        {
            var book = _mapper.Map<Book>(bookdto);
            _uow.BookRepository.AddBook(book);
            await _uow.SaveAsync();
            return StatusCode(201);
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
