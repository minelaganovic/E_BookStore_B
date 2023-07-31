using E_BookStore_B.Context;
using E_BookStore_B.Data.Repo;
using E_BookStore_B.Interfaces;
using System;

namespace E_BookStore_B.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;
        public UnitOfWork(AppDbContext appDbContext) 
        {
            _appDbContext=appDbContext;
        }
        public IBookRepository BookRepository => new BookRepository(_appDbContext);
        public async Task<bool> SaveAsyc()
        {
            return await _appDbContext.SaveChangesAsync()>0;
        }
    }
}
