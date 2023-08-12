using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetBooksQuery:IRequest<BookDTO>
    {
    }
}
