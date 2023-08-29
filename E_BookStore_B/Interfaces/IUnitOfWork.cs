namespace E_BookStore_B.Interfaces
{
    public interface IUnitOfWork
    {
        IBookRepository BookRepository { get; }
        IAutorRepository AutorRepository { get; }
        IIzdavacRepository IzdavacRepository { get; }
        IOrderRepository OrderRepository { get; }

        Task<bool> SaveAsync();
    }
}
