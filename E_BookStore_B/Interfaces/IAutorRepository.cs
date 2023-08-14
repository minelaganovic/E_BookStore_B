using E_BookStore_B.Models;

namespace E_BookStore_B.Interfaces
{
    public interface IAutorRepository
    {
        Task<Autor> GetAutorAsync(int id);
        Task<IEnumerable<Autor>> GetAutorAsync();

    }
}
