using E_BookStore_B.Data.Repo;
using E_BookStore_B.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_BookStore_B.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {


        private readonly IBookRepository _bookRepository;
        public BookController(IBookRepository brep)
        {
            _bookRepository= brep;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books= await _bookRepository.GetBooksAsync();
            return Ok(books);
        }
        [HttpPost]
        public async Task<IActionResult> AddBooks(Book book) 
        {
            _bookRepository.AddBook(book);
            await _bookRepository.SaveAsync();
            return StatusCode(201);
        }
        [HttpDelete ("delete/{ID}")]
        public async Task<IActionResult> DeleteBooks(int id)
        {
           _bookRepository.DeleteBook(id);
            await _bookRepository.SaveAsync();
            return Ok(id);
        }

    }
}
