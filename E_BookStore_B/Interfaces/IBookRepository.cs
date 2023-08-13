using E_BookStore_B.DTOs;
using E_BookStore_B.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace E_BookStore_B.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        Task<Book> GetBookAsync(int id);
        void AddBook(Book book);
        void DeleteBook(int bookId);
        Task<Book>FindBook(int bookId);
    }
}
