using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetSearchBookByTitleHandler:IRequestHandler<GetSearchBookByTitleQuery, List<BookDTO>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetSearchBookByTitleHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }
        public async Task<List<BookDTO>> Handle(GetSearchBookByTitleQuery request, CancellationToken cancellationToken)
        {
            var books = await _uow.BookRepository.GetSearchBook(request.naslov);
             return _mapper.Map<List<BookDTO>>(books);            
        }
    }
}
