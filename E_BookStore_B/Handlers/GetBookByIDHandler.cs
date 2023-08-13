using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;

namespace E_BookStore_B.Handlers
{
    public class GetBookByIDHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetBookByIDHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> Handle(GetBookByIDQuery request, CancellationToken cancellationToken)
        {
            var books = await _uow.BookRepository.FindBook(request.Id);
            if (books == null)
            {
                return null;
            }
            return _mapper.Map<List<BookDTO>>(books);
        }
    }
}
