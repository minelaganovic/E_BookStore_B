using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetNewBooksHandler : IRequestHandler<GetNewBooksQuery, List<BookDTO>>
    {
            private readonly IUnitOfWork _uow;
            private readonly IMapper _mapper;

            public GetNewBooksHandler(IUnitOfWork uow, IMapper mapper)
            {
                _uow = uow;
                _mapper = mapper;
            }

            public async Task<List<BookDTO>> Handle(GetNewBooksQuery request, CancellationToken cancellationToken)
            {
            int page = request.Page;
            int pageSize = request.PageSize;

            var books = await _uow.BookRepository.GetNewBooks(page, pageSize);
            return _mapper.Map<List<BookDTO>>(books);
        }
        }
}
