using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetAutorByIDQuery:IRequest<AutorDTO>
    {
        public int Id { get; set; }
        public GetAutorByIDQuery(int id)
        {
            Id = id;
        }
    }
}
