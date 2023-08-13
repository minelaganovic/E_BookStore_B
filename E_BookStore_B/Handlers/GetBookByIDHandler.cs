using AutoMapper;
using E_BookStore_B.DTOs;
using E_BookStore_B.Interfaces;
using E_BookStore_B.Queries;
using MediatR;

namespace E_BookStore_B.Handlers
{
    public class GetBookByIDHandler: IRequestHandler<GetBookByIDQuery, BookDTO>
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public GetBookByIDHandler(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<BookDTO> Handle(GetBookByIDQuery request, CancellationToken cancellationToken)
        {
            var books = await _uow.BookRepository.GetBookAsync(request.Id);
            if (books == null)
            {
                return null;
            }
            return _mapper.Map<BookDTO>(books);
        }
    }
}
