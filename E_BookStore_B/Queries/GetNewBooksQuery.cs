using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetNewBooksQuery : IRequest<List<BookDTO>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
