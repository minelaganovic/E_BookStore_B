using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetTopListBooksHndler: IRequestHandler<GetTopListBooksQuery, List<BookDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetTopListBooksHndler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> Handle(GetTopListBooksQuery request, CancellationToken cancellationToken)
        {
            var books = await _uow.BookRepository.GetTopListBooks();
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
