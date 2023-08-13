using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetBookByIDQuery:IRequest<BookDTO>
    {
        public int Id { get; set; }
        public GetBookByIDQuery(int id)
        {
            Id = id;
        }
    }
}
