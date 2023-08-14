using E_BookStore_B.Context;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Models;
using Microsoft.EntityFrameworkCore;

namespace E_BookStore_B.Data.Repo
{
    public class IzdavacRepository : IIzdavacRepository
    {
        private readonly AppDbContext authContext;
        public IzdavacRepository(AppDbContext appDbContext)
        {
            this.authContext = appDbContext;
        }
        public async Task<Izdavac>GetIzdavacAsync(int id)
        {
            return await authContext.Publishers.FirstOrDefaultAsync(p => p.id == id);
        }
        public async Task<IEnumerable<Izdavac>> GetIzdavacAsync()
        {
            return await authContext.Publishers.ToListAsync();
        }
    }
}
