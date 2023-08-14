using E_BookStore_B.Models;

namespace E_BookStore_B.Interfaces
{
    public interface IIzdavacRepository
    {
        Task<Izdavac> GetIzdavacAsync(int id);
        Task<IEnumerable<Izdavac>> GetIzdavacAsync();

    }
}
