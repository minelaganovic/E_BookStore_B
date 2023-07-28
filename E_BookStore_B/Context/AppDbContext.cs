using E_BookStore_B.Models;
using Microsoft.EntityFrameworkCore;

namespace E_BookStore_B.Context
{
    public class AppDbContext: DbContext
    {
        //konstruktor
        public AppDbContext(DbContextOptions <AppDbContext> options ): base (options)
        {

        }
        public DbSet<User> Users { get; set; }
        
        //modelBuilder je klasa koja pomaže za konekciju sa entitijem u .net
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
        }
    }
}
