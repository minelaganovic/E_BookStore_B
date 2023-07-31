using E_BookStore_B.Data.Repo;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        public BookController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books= await _uow.BookRepository.GetBooksAsync();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooks(Book book) 
        {
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
