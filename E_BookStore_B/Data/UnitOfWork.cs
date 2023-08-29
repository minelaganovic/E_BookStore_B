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
        public IAutorRepository AutorRepository =>  new AutorRepository(_appDbContext);

        public IIzdavacRepository IzdavacRepository =>  new IzdavacRepository(_appDbContext);

        public IOrderRepository OrderRepository => new OrderRepository(_appDbContext);


        public async Task<bool> SaveAsync()
        {
            return await _appDbContext.SaveChangesAsync()>0;
        }
    }
}
