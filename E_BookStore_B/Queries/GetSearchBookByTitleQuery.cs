using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetSearchBookByTitleQuery : IRequest<List<BookDTO>>
    {
        public string naslov { get; set; }
       public GetSearchBookByTitleQuery(string srchtext)
       {
                naslov=srchtext;
       }
    }
}
