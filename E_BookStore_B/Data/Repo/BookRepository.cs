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
            return await authContext.Books.ToListAsync();
        }

        public async Task<Book> FindBook(int bookId)
        {
            return await authContext.Books.FindAsync(bookId);
        }
        public async Task<Book> GetBookAsync(int bookid)
        {
           return await authContext.Books.FirstOrDefaultAsync(p => p.id == bookid);
        }
    }
}
