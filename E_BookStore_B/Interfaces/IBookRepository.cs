using E_BookStore_B.DTOs;
using E_BookStore_B.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace E_BookStore_B.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<IEnumerable<Book>> GetTopListBooks();

        Task<IEnumerable<Book>>GetNewBooks(int page, int pageSize);
        Task<Book> GetBookAsync(int id);
        Task<IEnumerable<Book>> GetSearchBook(string naslov);
        void AddBook(Book book);
        void DeleteBook(int bookId);
        Task<Book>FindBook(int bookId);
    }
}
