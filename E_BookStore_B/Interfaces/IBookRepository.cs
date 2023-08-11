using E_BookStore_B.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace E_BookStore_B.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        void AddBook(Book book);
        void DeleteBook(int bookId);
        Task<Book>FindBook(int bookId);
    }
}
