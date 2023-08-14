using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetIzdavacByIDQuery:IRequest<IzdavacDTO>
    {
        public int Id { get; set; }
        public GetIzdavacByIDQuery(int id)
        {
            Id = id;
        }
    }
}
