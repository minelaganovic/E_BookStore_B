using E_BookStore_B.Context;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using Microsoft.EntityFrameworkCore;

namespace E_BookStore_B.Data.Repo
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext authContext;
        public BookRepository(AppDbContext appDbContext)
        {
            this.authContext = appDbContext;
        }

        public void AddBook(Book book)
        {
            authContext.Books.AddAsync(book);
        }

        public void DeleteBook(int bookId)
        {
            var boook=authContext.Books.Find(bookId);
            authContext.Books.Remove(boook);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await authContext.Books.OrderByDescending(c=>c.godina_izdanja).ThenByDescending(c=>c.izdanje).ToListAsync();
        }
        public async Task<IEnumerable<Book>> GetSearchBook(string naslov)
        {
            naslov = naslov.ToLower(); 
            var matchingBooks = await authContext.Books
                .Where(book => book.naslov.ToLower().Contains(naslov))
                .ToListAsync();

            return matchingBooks;
        }

        public async Task<Book> FindBook(int bookId)
        {
            return await authContext.Books.FindAsync(bookId);
        }
        public async Task<Book> GetBookAsync(int bookid)
        {
           return await authContext.Books.FirstOrDefaultAsync(p => p.id == bookid);
        }
    
        public async Task<IEnumerable<Book>>GetNewBooks(int page, int pageSize)
        {
            if (page < 1)
            {
                page = 1;
            }

            int skipCount = (page - 1) * pageSize;

            return await authContext.Books
                .OrderByDescending(book => book.id)
                .Skip(skipCount)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}
