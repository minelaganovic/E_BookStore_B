using E_BookStore_B.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace E_BookStore_B.Data.Repo
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();
        void AddBook(Book book);
        void DeleteBook(int bookId);
        void UpdateBook(int bookId, Book book);
        Task<bool> SaveAsync();
    }
}
