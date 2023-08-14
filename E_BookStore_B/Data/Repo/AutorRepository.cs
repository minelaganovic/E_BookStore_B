using E_BookStore_B.Context;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using Microsoft.EntityFrameworkCore;

namespace E_BookStore_B.Data.Repo
{
    public class AutorRepository : IAutorRepository
    {
        private readonly AppDbContext authContext;
        public AutorRepository(AppDbContext appDbContext)
        {
            this.authContext = appDbContext;
        }
        public async Task<Autor> GetAutorAsync(int id)
        {
            return await authContext.Authors.FirstOrDefaultAsync(p => p.id == id);
        }
    }
}
