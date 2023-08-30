using E_BookStore_B.DTOs;
using MediatR;

namespace E_BookStore_B.Queries
{
    public class GetOrderByUIDQuery:IRequest<List<OrderDTO>>
    {
        public int UserID { get; set;}

        public GetOrderByUIDQuery(int uid)
        {
            UserID = uid;
        }
    }
}
