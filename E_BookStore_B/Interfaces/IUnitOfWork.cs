namespace E_BookStore_B.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        Task<bool> SaveAsync();
    }
}
